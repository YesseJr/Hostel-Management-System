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

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(b => b.booking_id); // Define primary key
                                                                      // or
                                                                      // modelBuilder.Entity<Booking>().HasNoKey(); // Define as keyless entity
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.UserId, iur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });
        }
        public DbSet<Room> Rooms { get; set; } // Table for rooms
        //public DbSet<Booking> Bookings { get; set; } // Table for bookings
        public DbSet<Tenant> Tenants { get; set; } // Table for tenants
        public DbSet<Payment> Payments { get; set; } // Table for payments
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
