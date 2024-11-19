using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyEagerLoadingPOC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        // The Department navigation property is marked as 'virtual' to enable Lazy Loading.
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
