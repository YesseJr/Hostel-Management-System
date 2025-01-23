namespace HostelManagementSystem.Models
{
    public class Booking
    {
        public int booking_id { get; set; } // Unique identifier for the booking
        public required string RoomNumber { get; set; } // The number or name of the room
        public required string ResidentName { get; set; } // Name of the person who made the booking
        public DateTime BookingDate { get; set; } // Date when the booking was made
        public DateTime CheckInDate { get; set; } // Date when the resident is expected to check-in
        public DateTime CheckOutDate { get; set; } // Date when the resident is expected to check-out
        public bool IsConfirmed { get; set; } // Confirmation status of the booking (whether the resident is confirmed)
        //public required ApplicationUser Tenant { get; set; }
        public required string UserId { get; set; }
        public int RoomId { get; set; }
        public int TenantId { get; internal set; }
        public string Status { get; set; } = "Pending";  // Default value
        public string PaymentStatus { get; set; } = "Unpaid";  // Default value
        public required Tenant Tenant { get; set; }
    }
}
