using Microsoft.AspNetCore.Mvc;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;

public class RegisterController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: Register
    public IActionResult Index()
    {
        return View();
    }

    // POST: Register
    [HttpPost]
    public async Task<IActionResult> Index(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Ensure FirstName and LastName are properly assigned
            var firstName = !string.IsNullOrWhiteSpace(model.FirstName) ? model.FirstName : "DefaultFirstName";
            var lastName = !string.IsNullOrWhiteSpace(model.LastName) ? model.LastName : "DefaultLastName";

            // Create ApplicationUser instance with initialized Bookings collection
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = firstName,
                LastName = lastName,
                FullName = $"{firstName} {lastName}",  // Set FullName here
                Bookings = new List<Booking>()  // Initialize Bookings collection
            };

            // Attempt to create the user
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Sign in the user after successful registration
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Redirect to home page or wherever you need
                return RedirectToAction("Index", "Home");
            }

            // Add errors to ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we get here, something went wrong, so show the form again
        return View(model);
    }
}
