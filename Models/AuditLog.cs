namespace HostelManagementSystem.Models
{
public class AuditLog
{
    public int Id { get; set; }
    public required string Action { get; set; }
    public required string Description { get; set; }
    public DateTime Timestamp { get; set; }
    public required string PerformedBy { get; set; }
    }
}