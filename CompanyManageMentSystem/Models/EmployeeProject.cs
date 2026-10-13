using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CompanyManageMentSystem.Models
{
    public class EmployeeProject
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee ?Employee { get; set; }
        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project ?Project { get; set; }
        [Required]
        [MaxLength(50)]
        public  string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
    }
}
