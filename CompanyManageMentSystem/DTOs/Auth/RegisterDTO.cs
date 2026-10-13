using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(150, MinimumLength = 20)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(30)]
        public string Role { get; set; }
    }
}
