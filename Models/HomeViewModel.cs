namespace HostelManagementSystem.Models
{
    public class HomeViewModel
    {
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int BookedRooms { get; set; }
        public required List<Booking> RecentBookings { get; set; }
    }
}
