using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeDatabaseManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CourseNameNotUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Course_Name",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_Course_Name",
                table: "Courses",
                column: "Course_Name",
                unique: true);
        }
    }
}
