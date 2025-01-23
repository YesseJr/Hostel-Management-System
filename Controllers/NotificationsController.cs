using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Models;
using HostelManagementSystem.Data;

namespace HostelManagementSystem.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notifications = _context.Notifications.ToList();
            return View(notifications);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Notifications.Add(notification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        public IActionResult Delete(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}