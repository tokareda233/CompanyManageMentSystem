using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.Project
{
    public class CreateProjectDTO
    {
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(100, 10000000)]
        public double Budget { get; set; }
        [Required]
      
        public int DepartmentId { get; set; }
    }
}
