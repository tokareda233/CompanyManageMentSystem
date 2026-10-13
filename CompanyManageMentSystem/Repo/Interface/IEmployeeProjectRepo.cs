using CompanyManageMentSystem.Models;

namespace CompanyManageMentSystem.Repo.Interface
{
    public interface IEmployeeProjectRepo:IGenericRepo<EmployeeProject>
    {
        Task<List<EmployeeProject>> GetEmployeeProjectsByEmployeeId(int employeeId);
    }
}
