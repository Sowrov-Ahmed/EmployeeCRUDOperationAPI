using Microsoft.EntityFrameworkCore;
using EmployeeCRUDOperationAPI.Models;

namespace EmployeeCRUDOperationAPI.Data
{
    public class EmployeeCRUDOperationAPIDbContext : DbContext
    {
        public EmployeeCRUDOperationAPIDbContext(DbContextOptions<EmployeeCRUDOperationAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Configure Employee entity
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 502030, EmployeeName = "Mehedi Hasan", EmployeeCode = "EMP319", EmployeeSalary = 50000 },
                new Employee { EmployeeId = 502031, EmployeeName = "Ashikur Rahman", EmployeeCode = "EMP321", EmployeeSalary = 45000 },
                new Employee { EmployeeId = 502032, EmployeeName = "Rakibul Islam", EmployeeCode = "EMP322", EmployeeSalary = 52000 }
            );

            modelBuilder.Entity<EmployeeAttendance>().HasData(
               new EmployeeAttendance { EmployeeId = 502030, AttendanceDate = new DateTime(2023, 06, 24), IsPresent = true, IsAbsent = false, IsOffday = false },
               new EmployeeAttendance { EmployeeId = 502031, AttendanceDate = new DateTime(2023, 06, 25), IsPresent = false, IsAbsent = true, IsOffday = false },
               new EmployeeAttendance { EmployeeId = 502032, AttendanceDate = new DateTime(2023, 06, 25), IsPresent = true, IsAbsent = false, IsOffday = false }
           );
        }
    }
}



