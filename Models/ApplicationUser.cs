using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HostelManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // First Name and Last Name properties
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        // Bookings collection property with an initialized empty list
        public required ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // FullName property that automatically splits FirstName and LastName
        public string FullName
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ');
                FirstName = parts.Length > 0 ? parts[0] : string.Empty;
                LastName = parts.Length > 1 ? parts[1] : string.Empty;
            }
        }

        // Parameterless constructor
        public ApplicationUser()
        {
            // Ensure Bookings is initialized in case it is not initialized in the constructor
            Bookings = new List<Booking>();
        }

        // Constructor with parameters to set FirstName and LastName
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Bookings = new List<Booking>(); // Initialize Bookings collection
        }
    }
}
