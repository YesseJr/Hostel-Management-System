using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HostelManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your custom DbSet for other models/tables
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; } // Table for rooms
        public DbSet<Tenant> Tenants { get; set; } // Table for tenants
        public DbSet<Payment> Payments { get; set; } // Table for payments
        public DbSet<AuditLog> AuditLogs { get; set; }

        // Customize the Identity model creation (optional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensures Identity tables are configured properly

            // Identity key configurations
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(iur => new { iur.UserId, iur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });

            // Add custom configurations for your models if necessary
            modelBuilder.Entity<Booking>().HasKey(b => b.booking_id); // Define primary key for Booking table

            // You can add more custom model configurations here if needed.
        }
    }
}
