using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateIndex(
                name: "IX_Category_Parent_Id",
                table: "Category",
                column: "Parent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Category_Id",
                table: "Course",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Trainer_Id",
                table: "Course",
                column: "Trainer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Lessons_Course_Id",
                table: "Course_Lessons",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_Courses_Course_Id",
                table: "Trainee_Courses",
                column: "Course_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Course_Lessons");

            migrationBuilder.DropTable(
                name: "Trainee_Courses");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
