using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Data;
using HostelManagementSystem.Models; // Ensure ApplicationUser is in this namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with MySQL configuration (adjust connection string as needed)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25)) // Update MySQL version to match the one you're using
    ));

// Register Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Optionally, register additional services (like logging, caching, etc.)
builder.Services.AddRazorPages(); // If you're using Razor Pages as well

// Set up logging configuration (useful for debugging and production monitoring)
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
    config.SetMinimumLevel(LogLevel.Information); // Change this for production
});

// Register custom services (if any)

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Display detailed error pages in development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Redirect to custom error page in production
    app.UseHsts(); // Enforce HTTPS in production
}

// Set up middleware pipeline
app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Enable static file serving (e.g., images, JS, CSS)
app.UseRouting(); // Set up routing

// Authorization middleware (can be customized later if using authentication)
app.UseAuthentication(); // Enable authentication
app.UseAuthorization(); // Enable authorization

// Map controller routes (default is {controller=Home}/{action=Index}/{id?})
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application
app.Run();
