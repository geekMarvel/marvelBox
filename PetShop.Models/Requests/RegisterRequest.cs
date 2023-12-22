using PetShop.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Requests
{
    public class RegisterRequest
    {

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{2,19}$", ErrorMessage = "Usernames must start with a letter and have 3 to 20 characters.")]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{6,}$", ErrorMessage = "Password must have at least 6 characters, including uppercase, lowercase, digit, and special character.")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        
        public string? Role { get; set; }
    }
}
