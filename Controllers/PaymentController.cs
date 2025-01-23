using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering; // Add this using directive

namespace HostelManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly HostelContext _context;

        public PaymentController(HostelContext context)
        {
            _context = context;
        }

        // Example action method for creating a payment
        public IActionResult Create()
        {
            ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "FirstName");
            return View();
        }

        // Additional action methods...
    }
}


public class PaymentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PaymentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var payments = _context.Payments.Include(static p => p.Tenant).ToList();
        return View(payments);
    }

    public IActionResult Create()
    {
        ViewBag.TenantId = new SelectList(_context.Tenants, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Payment payment)
    {
        if (ModelState.IsValid)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.TenantId = new SelectList(_context.Tenants, "Id", "Name", payment.TenantId);
        return View(payment);
    }

    public IActionResult Delete(int id)
    {
        var payment = _context.Payments.Include(p => p.Tenant).FirstOrDefault(p => p.Id == id);
        if (payment == null)
        {
            return NotFound();
        }
        return View(payment);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var payment = _context.Payments.Find(id);
        if (payment != null)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}