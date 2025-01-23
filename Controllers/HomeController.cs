using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Models; // Assuming your models are in this namespace
using HostelManagementSystem.Data; // Assuming your data context (DbContext) is in this namespace


namespace HostelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the database context
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public IActionResult Index()
        {
            // Fetch the data for the dashboard
            var totalRooms = _context.Rooms.Count(); // Example: Count of all rooms
            var availableRooms = _context.Rooms.Count(static r => r.IsAvailable); // Rooms that are available
            var bookedRooms = _context.Rooms.Count(static r => !r.IsAvailable); // Rooms that are booked
            var recentBookings = _context.Bookings
                                          .OrderByDescending(static b => b.BookingDate)
                                          .Take(5) // Get the 5 most recent bookings
                                          .ToList();

            // Prepare a ViewModel (optional, but can be useful if you have complex data)
            var model = new HomeViewModel
            {
                TotalRooms = totalRooms,
                AvailableRooms = availableRooms,
                BookedRooms = bookedRooms,
                RecentBookings = recentBookings
            };

            return View(model); // Pass data to the view
        }
    }
}
