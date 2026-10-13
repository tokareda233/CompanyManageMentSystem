using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
