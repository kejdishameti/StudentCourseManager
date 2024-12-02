using Microsoft.EntityFrameworkCore;
using StudentCourseManager.Models;

namespace StudentCourseManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

            // Seed data for Students
            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, Name = "Alex Smith", Email = "john.smith@example.com" },
                new Student { ID = 2, Name = "Jane Louis", Email = "jane.louis@example.com" }
            );

            // Seed data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Title = "Introduction to Computer Science", Description = "Basic concepts of computer science" },
                new Course { ID = 2, Title = "Advanced Mathematics", Description = "In-depth study of mathematical concepts" }
            );

            // Seed data for Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1, EnrollmentDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Enrollment { StudentId = 1, CourseId = 2, EnrollmentDate = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Enrollment { StudentId = 2, CourseId = 1, EnrollmentDate = new DateTime(2024, 1, 3, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
