// File: Models/LoginModel.cs
using System.ComponentModel.DataAnnotations;


namespace HostelManagementSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
