using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Models;

namespace HostelManagementSystem.Data
{
    public class HostelContext : DbContext
    {
        public HostelContext(DbContextOptions<HostelContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Room-Tenant relationship (one-to-many)
            modelBuilder.Entity<Tenant>()
                .HasOne(t => t.Room)
                .WithMany(r => r.Tenants)
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Tenant-Booking relationship (one-to-many)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Tenant)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure Payment-Tenant relationship (one-to-many)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Tenant)
                .WithMany(t => t.Payments) // Ensure this is correctly referenced
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Booking's composite unique constraint (room and date)
            modelBuilder.Entity<Booking>()
                .HasIndex(b => new { b.RoomId, b.CheckInDate })
                .IsUnique();
        }
    }
}
