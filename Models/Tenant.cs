using System.ComponentModel.DataAnnotations;

namespace HostelManagementSystem.Models
{
    public class Tenant
    {
        public int Id { get; set; } // Unique identifier for the tenant
        public required string Name { get; set; } // Full name of the tenant

        public required string Phone { get; set; }
        public required string Email { get; set; } // Tenant's email address
        public DateTime DateOfBirth { get; set; } // Tenant's date of birth
        public required string Address { get; set; } // Tenant's residential address
        public int RoomId { get; set; } // Foreign key linking to the Room
        public required Room Room { get; set; } // Navigation property to Room
        public DateTime MoveInDate { get; set; } // The date when the tenant moved in
        public DateTime MoveOutDate { get; set; } // The date when the tenant moved out (nullable)

        public required ICollection<Booking> Bookings { get; set; }
        public required ICollection<Payment> Payments { get; set; }
    }
}
