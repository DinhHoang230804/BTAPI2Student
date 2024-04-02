using BTWebAPI_1.Models;
using Microsoft.EntityFrameworkCore;

namespace BTWebAPI_1.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Courses>(a =>
            {
                a.HasData(new Courses
                {
                    CourseId = new Guid("1"),
                    CourseName = "Anh",
                    Description = "Hoc ve tieng anh",
                });
                a.HasData(new Courses
                {
                    CourseId = new Guid("2"),
                    CourseName = "Toan",
                    Description = "Hoc ve  mon Toan ",
                });
                a.HasData(new Courses
                {
                    CourseId = new Guid("3"),
                    CourseName = "Hoa",
                    Description = "Hoc ve  mon Hoa ",
                });
            });

            _builder.Entity<StudentCourses>(b =>
            {
            b.HasData(new StudentCourses
            {
                Studentid = new Guid("1"),
                CourseId = new Guid("1"),
            });
            b.HasData(new StudentCourses
            {
                Studentid = new Guid("2"),
                CourseId = new Guid("2"),
            });
            b.HasData(new StudentCourses
            {
                Studentid = new Guid("3"),
                CourseId = new Guid("3"),
            });
            });
            _builder.Entity<Students>(c =>
            {
                c.HasData(new Students
                {
                    StudentID = new Guid("1"),
                    Name ="Ha Thi Kim Loan",
                });
                c.HasData(new Students
                {
                    StudentID = new Guid("2"),
                    Name = "Tran Quang Dung",
                });
                c.HasData(new Students
                {
                    StudentID = new Guid("3"),
                    Name = "Nguyen Kim Ha",
                });
            });
        }
    }
}