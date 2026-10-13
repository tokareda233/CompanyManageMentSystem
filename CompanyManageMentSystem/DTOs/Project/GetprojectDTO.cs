using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.Project
{
    public class GetprojectDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string? Description { get; set; }
       
        public DateTime StartDate { get; set; }
       
        public double Budget { get; set; }
       
        public int DepartmentId { get; set; }
    }
}
