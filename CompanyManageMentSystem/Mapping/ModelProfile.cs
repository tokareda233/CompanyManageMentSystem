using AutoMapper;
using CompanyManageMentSystem.DTOs.Department;
using CompanyManageMentSystem.DTOs.Employee;
using CompanyManageMentSystem.DTOs.Project;
using CompanyManageMentSystem.Models;

namespace CompanyManageMentSystem.Mapping
{
    public class ModelProfile:Profile
    {
        public ModelProfile() {

            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<Department, GetDepartmentDTO>();


            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<Employee, GetEmployeeDTO>();


            CreateMap<CreateProjectDTO, Project>();
            CreateMap<Project, GetprojectDTO>();


        }
    }
}
