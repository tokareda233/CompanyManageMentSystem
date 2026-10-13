using CompanyManageMentSystem.Data;
using CompanyManageMentSystem.Models;
using CompanyManageMentSystem.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace CompanyManageMentSystem.Repo.Implementation
{
    public class EmployeeProjectRepo : GenericRepo<EmployeeProject>, IEmployeeProjectRepo
    {
        private readonly AppDbContext _context;
        public EmployeeProjectRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeProject>> GetEmployeeProjectsByEmployeeId(int employeeId)
        {
            return await _context.EmployeeProjects.Where(c => c.EmployeeId == employeeId).ToListAsync();
        }
    }
}
