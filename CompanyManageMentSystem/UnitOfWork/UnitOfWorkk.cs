using CompanyManageMentSystem.Data;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.Repo.Interface;

namespace CompanyManageMentSystem.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Department> Departments {  get;  }

        public IEmployeeRepo Employee {  get; }

        public IGenericRepo<Project> Projects {  get; }

        public IEmployeeProjectRepo EmployeeProject {  get; }

        public IAuthRepo AuthRepo {  get; }

        public UnitOfWorkk(AppDbContext context, IGenericRepo<Department> departments, IEmployeeRepo employee, IGenericRepo<Project> projects, IEmployeeProjectRepo employeeProject, IAuthRepo authRepo)
        {
            _context = context;
            Departments = departments;
            Employee = employee;
            Projects = projects;
            EmployeeProject = employeeProject;
            AuthRepo = authRepo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveAsync()
        {
           _context.SaveChangesAsync();
        }
    }
}
