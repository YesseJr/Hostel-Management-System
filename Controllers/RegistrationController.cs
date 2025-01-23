using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class RegisterController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Split FullName into FirstName and LastName (adjust logic if needed)
            var nameParts = model.FullName?.Split(' ') ?? new[] { "DefaultFirstName", "DefaultLastName" };
            var firstName = nameParts.Length > 0 ? nameParts[0] : "DefaultFirstName";
            var lastName = nameParts.Length > 1 ? nameParts[1] : "DefaultLastName";

            // Create ApplicationUser instance
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = firstName,
                LastName = lastName,
                Bookings = new List<Booking>()
            };

            // Attempt to create the user
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            // Add errors to ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }
}
