using CompanyManageMentSystem.Models;

namespace CompanyManageMentSystem.Repo.Interface
{
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {

        Task<List<Employee>> SearchByName(string name);
        Task<List<Employee>> GetEmplyeesByDepartmentid(int departmentid);
    }
}
