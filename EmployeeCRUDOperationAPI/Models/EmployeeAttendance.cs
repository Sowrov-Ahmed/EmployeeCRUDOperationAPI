using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUDOperationAPI.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsOffday { get; set; }
    }
}
