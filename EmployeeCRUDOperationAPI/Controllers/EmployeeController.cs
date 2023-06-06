using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EmployeeCRUDOperationAPI.Models;
using EmployeeCRUDOperationAPI.Data;

namespace EmployeeCRUDOperationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeCRUDOperationAPIDbContext _dbContext;

        public EmployeeController(EmployeeCRUDOperationAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // API01: Update an employee's Employee Code [Don't allow duplicate employee code]
        [HttpPut("{id}/employeecode")]
        public IActionResult UpdateEmployeeCode(int id, [FromBody] string employeeCode)
        {
            var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            var duplicateEmployee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode);
            if (duplicateEmployee != null)
            {
                return BadRequest("Employee code already exists.");
            }

            existingEmployee.EmployeeCode = employeeCode;
            _dbContext.SaveChanges();

            return Ok();
        }

        // API02: Get all employees based on maximum to minimum salary
        [HttpGet]
        public IActionResult GetEmployeesBySalary()
        {
            var employees = _dbContext.Employees.OrderByDescending(e => e.EmployeeSalary).ToList();
            return Ok(employees);
        }

        // API03: Find all employees who are absent at least one day
        [HttpGet("absent")]
        public IActionResult GetAbsentEmployees()
        {
            var absentEmployees = _dbContext.EmployeeAttendances
                .Where(a => a.IsAbsent)
                .Select(a => a.EmployeeId)
                .Distinct()
                .ToList();

            var employees = _dbContext.Employees.Where(e => absentEmployees.Contains(e.EmployeeId)).ToList();

            return Ok(employees);
        }

        // API04: Get monthly attendance report of all employees
        [HttpGet("attendance/report")]
        public IActionResult GetMonthlyAttendanceReport()
        {
            var monthlyReport = _dbContext.EmployeeAttendances
                .Join(_dbContext.Employees,
                    attendance => attendance.EmployeeId,
                    employee => employee.EmployeeId,
                    (attendance, employee) => new
                    {
                        EmployeeName = employee.EmployeeName,
                        MonthName = attendance.AttendanceDate.ToString("MMMM"),
                        TotalPresent = attendance.IsPresent ? 1 : 0,
                        TotalAbsent = attendance.IsAbsent ? 1 : 0,
                        TotalOffday = attendance.IsOffday ? 1 : 0
                    })
                .GroupBy(r => new { r.EmployeeName, r.MonthName })
                .Select(g => new
                {
                    g.Key.EmployeeName,
                    g.Key.MonthName,
                    TotalPresent = g.Sum(r => r.TotalPresent),
                    TotalAbsent = g.Sum(r => r.TotalAbsent),
                    TotalOffday = g.Sum(r => r.TotalOffday)
                })
                .ToList();

            return Ok(monthlyReport);
        }
    }
}
