using System.ComponentModel.DataAnnotations;

namespace HostelManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public required string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } // Add this line
        public required string UserId { get; set; }
        public required string Method { get; set; }
        public required Tenant Tenant { get; set; }
        public DateTime PaymentDate { get; set; }
        public required string TenantId { get; set; }

        public required ApplicationUser User { get; set; }
        
    }
}
