using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeDatabaseManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Customized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Courses_CourseId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Departments_DepartmentId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "EnrollmentNumber",
                table: "Students",
                newName: "Enrollment_Number");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Students",
                newName: "DOB");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_Department");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "GradeValue",
                table: "Grades",
                newName: "Grade_Value");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Grades",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                newName: "IX_Grades_Student");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                newName: "IX_Grades_Course");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Faculties",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Faculties",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Faculties",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_DepartmentId",
                table: "Faculties",
                newName: "IX_Faculties_Department");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollments",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                newName: "IX_Enrollments_Student");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_Course");

            migrationBuilder.RenameColumn(
                name: "HeadOfDepartment",
                table: "Departments",
                newName: "HOD");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "Department_Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Courses",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "Course_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                newName: "IX_Courses_Department");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Attendances",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Attendances",
                newName: "P/A");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Attendances",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                newName: "IX_Attendances_Student");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CourseId",
                table: "Attendances",
                newName: "IX_Attendances_Course");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Enrollment_Number",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Faculties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Faculties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Enrollments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HOD",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Department_Name",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Course_Name",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Enrollment_Number",
                table: "Students",
                column: "Enrollment_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Department_Name",
                table: "Departments",
                column: "Department_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Course_Name",
                table: "Courses",
                column: "Course_Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Courses_Course",
                table: "Attendances",
                column: "Course",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_Student",
                table: "Attendances",
                column: "Student",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department",
                table: "Courses",
                column: "Department",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_Course",
                table: "Enrollments",
                column: "Course",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_Student",
                table: "Enrollments",
                column: "Student",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Departments_Department",
                table: "Faculties",
                column: "Department",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_Course",
                table: "Grades",
                column: "Course",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_Student",
                table: "Grades",
                column: "Student",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Department",
                table: "Students",
                column: "Department",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Courses_Course",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_Student",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_Course",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_Student",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Departments_Department",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_Course",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_Student",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Department",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Enrollment_Number",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Department_Name",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Course_Name",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Enrollment_Number",
                table: "Students",
                newName: "EnrollmentNumber");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DOB",
                table: "Students",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Department",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Student",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Grade_Value",
                table: "Grades",
                newName: "GradeValue");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Grades",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Student",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Course",
                table: "Grades",
                newName: "IX_Grades_CourseId");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Faculties",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Faculties",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Faculties",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_Department",
                table: "Faculties",
                newName: "IX_Faculties_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Student",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Enrollments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_Student",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_Course",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.RenameColumn(
                name: "HOD",
                table: "Departments",
                newName: "HeadOfDepartment");

            migrationBuilder.RenameColumn(
                name: "Department_Name",
                table: "Departments",
                newName: "DepartmentName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Courses",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Course_Name",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Department",
                table: "Courses",
                newName: "IX_Courses_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Student",
                table: "Attendances",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "P/A",
                table: "Attendances",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Attendances",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_Student",
                table: "Attendances",
                newName: "IX_Attendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_Course",
                table: "Attendances",
                newName: "IX_Attendances_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EnrollmentNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadOfDepartment",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Courses_CourseId",
                table: "Attendances",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Departments_DepartmentId",
                table: "Faculties",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
