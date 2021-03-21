using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeChallenge.Persistence.Migrations
{
    public partial class Added_EmployeeSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateHired", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, new DateTime(2021, 3, 19, 18, 53, 53, 338, DateTimeKind.Local).AddTicks(5671), "Elmer", 1, "San Pedro" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateHired", "FirstName", "Gender", "LastName" },
                values: new object[] { 2, new DateTime(2021, 3, 19, 18, 53, 53, 339, DateTimeKind.Local).AddTicks(3432), "Bill", 1, "Gate" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateHired", "FirstName", "Gender", "LastName" },
                values: new object[] { 3, new DateTime(2021, 3, 19, 18, 53, 53, 339, DateTimeKind.Local).AddTicks(3500), "Sarah", 2, "McGregor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
