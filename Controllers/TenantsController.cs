using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Data;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace HostelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class TenantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tenant
        public async Task<IActionResult> Index()
        {
            var tenants = await _context.Tenants.Include(static t => t.Room).ToListAsync();
            return View(tenants);
        }

        // GET: Tenant/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms.Where(static r => r.IsAvailable), "Id", "Name");
            return View();
        }

        // POST: Tenant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Tenants.Add(tenant);
                await _context.SaveChangesAsync();

                // Update room availability
                var room = await _context.Rooms.FindAsync(tenant.RoomId);
                if (room != null)
                {
                    room.IsAvailable = false;
                    _context.Rooms.Update(room);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms.Where(static r => r.IsAvailable), "Id", "Name", tenant.RoomId);
            return View(tenant);
        }

        // GET: Tenant/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", tenant.RoomId);
            return View(tenant);
        }

        // POST: Tenant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", tenant.RoomId);
            return View(tenant);
        }

        // GET: Tenant/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var tenant = await _context.Tenants.Include(t => t.Room).FirstOrDefaultAsync(t => t.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();

                // Update room availability
                var room = await _context.Rooms.FindAsync(tenant.RoomId);
                if (room != null)
                {
                    room.IsAvailable = true;
                    _context.Rooms.Update(room);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
