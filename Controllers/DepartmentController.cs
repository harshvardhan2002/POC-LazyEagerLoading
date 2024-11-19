using LazyEagerLoadingPOC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LazyEagerLoadingPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public DepartmentController(IEmployeeService service)
        {
            _service = service;
        }

        // Endpoint for Lazy Loading
        [HttpGet("lazy")]
        public IActionResult GetLazy()
        {
            var departments = _service.GetAllDepartmentsLazy();
            return Ok(departments);
        }

        // Endpoint for Eager Loading
        [HttpGet("eager")]
        public IActionResult GetEager()
        {
            var departments = _service.GetAllDepartmentsEager();
            return Ok(departments);
        }
    }
}
