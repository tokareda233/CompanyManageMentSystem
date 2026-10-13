using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public ICollection<Employee> ?Employees { get; set; }
        public ICollection<Project> ?Projects { get; set; }
    }
}
