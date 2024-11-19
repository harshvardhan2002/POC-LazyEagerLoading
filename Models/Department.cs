using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace LazyEagerLoadingPOC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        //virtual keyword enables Lazy Loading
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
