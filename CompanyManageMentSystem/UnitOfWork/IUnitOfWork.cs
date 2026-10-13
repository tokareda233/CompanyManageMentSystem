using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.Repo.Interface;

namespace CompanyManageMentSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepo<Department> Departments { get; }
        IGenericRepo<Project> Projects { get; }
        IEmployeeRepo Employee { get; }

        IEmployeeProjectRepo EmployeeProject { get; }
        IAuthRepo AuthRepo { get; }
        void Save();
        void SaveAsync();
    }
}
