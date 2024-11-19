using LazyEagerLoadingPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyEagerLoadingPOC.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
    }
}
