using CompanyManageMentSystem.Data;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompanyManageMentSystem.Repo.Implementation
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmplyeesByDepartmentid(int departmentid)
        {
            return await _context.Employees.Where(x=>x.DepartmentId==departmentid).ToListAsync();   
        }

        public async Task<List<Employee>> SearchByName(string name)
        {
            return await _context.Employees.Where(c=>c.FullName.Contains(name)).ToListAsync();
        }
    }
}
