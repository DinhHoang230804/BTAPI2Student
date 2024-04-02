using BTWebAPI_1.Models;
using Microsoft.EntityFrameworkCore;

namespace BTWebAPI_1.Data
{
    public class MySQL:DbContext
    {
        public MySQL(DbContextOptions<MySQL> options) : base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.Studentid, sc.CourseId });
        }

    }
}
