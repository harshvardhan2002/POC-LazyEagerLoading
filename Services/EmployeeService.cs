using LazyEagerLoadingPOC.Data;
using LazyEagerLoadingPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyEagerLoadingPOC.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly EmployeeContext _context;
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        // Lazy Loading-> Employees are loaded when accessed
        //it is triggered by accessing navigation properties ( here in this case, department.Employees triggeres it)
        public List<Department> GetAllDepartmentsLazy()
        {
            var departments = _context.Departments.ToList();
            foreach (var department in departments)
            {
                var employees = department.Employees.ToList();
            }
            return departments;
        }

        // Eager Loading-> 
        //.Include(d=>d.Employees) fetches employees with its department (when a department is fetched)
        public List<Department> GetAllDepartmentsEager()
        {
            return _context.Departments.Include(d => d.Employees).ToList();
        }
    }
}
