using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TASK17_09.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("SchoolContext")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // One-to-One relationship between Student and StudentDetails
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Detail)  // Student can have one or zero details
                .WithRequired(sd => sd.Student);     // StudentDetails must have a Student

            // One-to-Many relationship between Teacher and Courses
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)  // Teacher can have many Courses
                .WithRequired(c => c.Teacher)  // Each Course must have a Teacher
                .HasForeignKey(c => c.TeacherId);  // Use TeacherId as Foreign Key

            base.OnModelCreating(modelBuilder);
        }
    }
}