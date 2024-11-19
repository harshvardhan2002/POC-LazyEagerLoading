using LazyEagerLoadingPOC.Models;

namespace LazyEagerLoadingPOC.Services
{
    public interface IEmployeeService
    {
        List<Department> GetAllDepartmentsLazy();
        List<Department> GetAllDepartmentsEager();
    }
}
