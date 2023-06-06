using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeCRUDOperationAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "EmployeeId", "AttendanceDate", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 502030, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true },
                    { 502031, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false },
                    { 502032, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary" },
                values: new object[,]
                {
                    { 502030, "EMP319", "Mehedi Hasan", 50000m },
                    { 502031, "EMP321", "Ashikur Rahman", 45000m },
                    { 502032, "EMP322", "Rakibul Islam", 52000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeId",
                keyValue: 502030);

            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeId",
                keyValue: 502031);

            migrationBuilder.DeleteData(
                table: "EmployeeAttendances",
                keyColumn: "EmployeeId",
                keyValue: 502032);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502030);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502031);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 502032);
        }
    }
}
