using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManageMentSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string ?Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(100,10000000)]
        public double Budget { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department ?Department { get; set; }
        public ICollection<EmployeeProject>? EmplyeeProjects { get; set; }
    }
}
