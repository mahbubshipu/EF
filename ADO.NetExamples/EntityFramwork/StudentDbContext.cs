using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
    public class StudentDbContext:DbContext
    {
        private readonly string _connectionString;
        private readonly string _assembleName;
        public StudentDbContext()
        {
            _connectionString = "Server=DESKTOP-82TEKUF\\SQLEXPRESS;Database=CSharpB6;User Id=csharpb6;Password=12345;";
            _assembleName = typeof(Program).Assembly.FullName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)//Connection string set korar jonno
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assembleName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Fluent API
        {
            modelBuilder.Entity<Course>().HasMany(x => x.Topics).WithOne(i => i.Course);//Explicitly One to many relationship

            modelBuilder.Entity<CourseStudent>().HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<CourseStudent>().HasOne(y => y.Course).WithMany(z => z.EnrolledStudents).HasForeignKey(x => x.CourseId);//Many to many

            modelBuilder.Entity<CourseStudent>().HasOne(s => s.Student).WithMany(c => c.EnrolledCourses).HasForeignKey(s => s.StudentId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
    }
}
