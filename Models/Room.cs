using System.ComponentModel.DataAnnotations;

namespace HostelManagementSystem.Models
{
    public class Room
    {
        public int Id { get; set; } // Unique identifier for the room
        public required string RoomNumber { get; set; } // The number or name of the room
        public bool IsAvailable { get; set; } // Whether the room is available or not
        public decimal Price { get; set; } // Price per night
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public required ICollection<Tenant> Tenants { get; set; }
    }
}
