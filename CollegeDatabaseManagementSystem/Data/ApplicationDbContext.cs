using Microsoft.EntityFrameworkCore;
using CollegeDatabaseManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CollegeDatabaseManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Many-to-One Student-Department
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //Many-to-One Course-Department
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //Many-to-One Faculty-Department
            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.Department)
                .WithMany(d => d.Faculties)
                .HasForeignKey(f => f.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //Many-to-One (Enrollment with Student & Course)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e =>e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            //Many-to-One (Grade with Student & Course)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            //Many-to-One (Attendance with Student & Course)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            //Database tables customization
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentId);
                entity.Property(d => d.DepartmentName).IsRequired().HasMaxLength(50).HasColumnName("Department_Name");
                entity.Property(d => d.HeadOfDepartment).IsRequired().HasMaxLength(50).HasColumnName("HOD");
                entity.HasIndex(d => d.DepartmentName).IsUnique();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);
                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(50).HasColumnName("First_Name");
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(50).HasColumnName("Last_Name");
                entity.Property(s => s.DateOfBirth).HasColumnType("date").IsRequired().HasColumnName("DOB");
                entity.Property(s => s.EnrollmentNumber).IsRequired().HasColumnName("Enrollment_Number");
                entity.Property(s => s.DepartmentId).IsRequired().HasColumnName("Department");
                entity.HasIndex(s => s.EnrollmentNumber).IsUnique();
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(f => f.FacultyId);
                entity.Property(f => f.FirstName).IsRequired().HasMaxLength(50).HasColumnName("First_Name");
                entity.Property(f => f.LastName).IsRequired().HasMaxLength(50).HasColumnName("Last_Name");
                entity.Property(f => f.DepartmentId).IsRequired().HasColumnName("Department");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);
                entity.Property(c => c.CourseName).IsRequired().HasMaxLength(50).HasColumnName("Course_Name");
                entity.Property(c => c.Credits).IsRequired().HasColumnName("Credits");
                entity.Property(c => c.DepartmentId).IsRequired().HasColumnName("Department");
            });


            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(a => a.AttendanceId);
                entity.Property(a => a.CourseId).IsRequired().HasColumnName("Course");
                entity.Property(a => a.StudentId).IsRequired().HasColumnName("Student");
                entity.Property(a => a.Date).IsRequired().HasColumnName("Date");
                entity.Property(a => a.Status).IsRequired().HasColumnName("P/A");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(en => en.EnrollmentID);
                entity.Property(en => en.CourseId).IsRequired().HasColumnName("Course");
                entity.Property(en => en.StudentId).IsRequired().HasColumnName("Student");
                entity.Property(en => en.Semester).IsRequired().HasColumnName("Semester");
                entity.Property(en => en.Year).IsRequired(false).HasColumnName("Year");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(g => g.GradeID);
                entity.Property(g => g.CourseId).IsRequired().HasColumnName("Course");
                entity.Property(g => g.StudentId).IsRequired().HasColumnName("Student");
                entity.Property(g => g.GradeValue).IsRequired().HasColumnName("Grade_Value");
            });
        }
    }
}
