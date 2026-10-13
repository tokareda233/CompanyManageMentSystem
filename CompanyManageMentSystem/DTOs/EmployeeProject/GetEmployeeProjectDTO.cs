using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.EmployeeProject
{
    public class GetEmployeeProjectDTO
    {
        public int Id { get; set; }
      
       
        public int EmployeeId { get; set; }
      
       
       
        public int ProjectId { get; set; }
       
      
        public string AssignedRole { get; set; }
    
        public DateTime AssignedDate { get; set; }
    }
}
