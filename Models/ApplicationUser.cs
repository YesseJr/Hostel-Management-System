using Microsoft.AspNetCore.Identity;


namespace HostelManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required ICollection<Booking> Bookings { get; set; } = new List<Booking>();
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
        }

        // Constructor with parameters
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
       // public required string Bookings { get; set; }
        
    }
}
