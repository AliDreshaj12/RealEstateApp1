using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.DTO
{
    public class Register
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
