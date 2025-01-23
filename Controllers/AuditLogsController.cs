using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Data;

public class AuditLogsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuditLogsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var logs = _context.AuditLogs.OrderByDescending(static a => a.Timestamp).ToList();
        return View(logs);
    }
}