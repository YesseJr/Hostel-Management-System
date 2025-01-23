using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HostelManagementSystem.Models;


namespace HostelManagementSystem.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
