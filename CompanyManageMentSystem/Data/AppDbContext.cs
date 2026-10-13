using CompanyManageMentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManageMentSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId);

             modelBuilder.Entity<Project>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.DepartmentId);


            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x=>x.Employee)
                .WithMany(x=>x.EmplyeeProjects)
                .HasForeignKey(x=>x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Project)
                .WithMany(x => x.EmplyeeProjects)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<EmployeeProject>()
                .HasIndex(x => new { x.ProjectId, x.EmployeeId }).IsUnique();

        }

    }
}
