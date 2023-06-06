using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUDOperationAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal EmployeeSalary { get; set; }
    }
}
