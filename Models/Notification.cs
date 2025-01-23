using System.ComponentModel.DataAnnotations;

namespace HostelManagementSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public required string Message { get; set; }
        public DateTime DateCreated { get; set; }
        // Add other properties as needed
    }
}
