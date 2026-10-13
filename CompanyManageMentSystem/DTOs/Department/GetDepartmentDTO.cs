using System.ComponentModel.DataAnnotations;

namespace CompanyManageMentSystem.DTOs.Department
{
    public class GetDepartmentDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Location { get; set; }
    }
}
