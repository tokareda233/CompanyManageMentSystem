using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.EmployeeProject
{
    public class CreateEmployeeProjectDTO
    {
      
        [Required]
        public int EmployeeId { get; set; }
       
        [Required]
        public int ProjectId { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }
}
