using BTWebAPI_1.Data;
using BTWebAPI_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BTWebAPI_1.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly MySQL _db;

        public LibraryService(MySQL db)
        {
            _db = db;
        }

        // Students Services

        public async Task<List<Students>> GetStudentsAsync()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Students> GetStudentsAsync(Guid id)
        {
            try
            {
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Students> AddStudentsAsync(Students student)
        {
            try
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Students> UpdateStudentsAsync(Students student)
        {
            try
            {
                _db.Entry(student).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentsAsync(Students student)
        {
            try
            {
                var existingStudent = await _db.Students.FindAsync(student.StudentID);
                if (existingStudent == null)
                {
                    return (false, "Student not found.");
                }

                _db.Students.Remove(existingStudent);
                await _db.SaveChangesAsync();
                return (true, "Student deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        // Courses Services

        public async Task<List<Courses>> GetCoursesAsync()
        {
            try
            {
                return await _db.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Courses> GetCourseAsync(Guid id)
        {
            try
            {
                return await _db.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Courses> AddCourseAsync(Courses course)
        {
            try
            {
                await _db.Courses.AddAsync(course);
                await _db.SaveChangesAsync();
                return course;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<Courses> UpdateCourseAsync(Courses course)
        {
            try
            {
                _db.Entry(course).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return course;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourseAsync(Courses course)
        {
            try
            {
                var existingCourse = await _db.Courses.FindAsync(course.CourseId);
                if (existingCourse == null)
                {
                    return (false, "Course not found.");
                }

                _db.Courses.Remove(existingCourse);
                await _db.SaveChangesAsync();
                return (true, "Course deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        // StudentCourses Services

        public async Task<List<StudentCourses>> GetStudentCoursesAsync()
        {
            try
            {
                return await _db.StudentCourses.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<StudentCourses> GetStudentCourseAsync(Guid studentId, Guid courseId)
        {
            try
            {
                return await _db.StudentCourses.FindAsync(studentId, courseId);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<StudentCourses> AddStudentCourseAsync(StudentCourses studentCourse)
        {
            try
            {
                await _db.StudentCourses.AddAsync(studentCourse);
                await _db.SaveChangesAsync();
                return studentCourse;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<StudentCourses> UpdateStudentCourseAsync(StudentCourses studentCourse)
        {
            try
            {
                _db.Entry(studentCourse).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return studentCourse;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentCourseAsync(StudentCourses studentCourse)
        {
            try
            {
                var existingStudentCourse = await _db.StudentCourses.FindAsync(studentCourse.Studentid, studentCourse.CourseId);
                if (existingStudentCourse == null)
                {
                    return (false, "StudentCourse not found.");
                }

                _db.StudentCourses.Remove(existingStudentCourse);
                await _db.SaveChangesAsync();
                return (true, "StudentCourse deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        public Task<List<Students>> GetStudentssAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentCourses>> GetStudentsCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourses> GetStudentsCourseAsync(Guid studentId, Guid courseId)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Students>>> ILibraryService.GetStudentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
