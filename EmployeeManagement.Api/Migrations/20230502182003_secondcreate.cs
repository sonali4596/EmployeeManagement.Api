using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class secondcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "MasterEmployees",
                newName: "DepartmentIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterEmployees_DepartmentIdId",
                table: "MasterEmployees",
                column: "DepartmentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterEmployees_Departments_DepartmentIdId",
                table: "MasterEmployees",
                column: "DepartmentIdId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterEmployees_Departments_DepartmentIdId",
                table: "MasterEmployees");

            migrationBuilder.DropIndex(
                name: "IX_MasterEmployees_DepartmentIdId",
                table: "MasterEmployees");

            migrationBuilder.RenameColumn(
                name: "DepartmentIdId",
                table: "MasterEmployees",
                newName: "DepartmentId");
        }
    }
}
