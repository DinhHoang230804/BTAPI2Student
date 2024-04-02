using BTWebAPI_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTWebAPI_1.Services
{
    public interface ILibraryService
    {
        // Students Services
        Task<List<Students>> GetStudentssAsync(); // GET All Studentss
        Task<Students> GetStudentsAsync(Guid id); // GET Single Students
        Task<Students> AddStudentsAsync(Students Students); // POST New Students
        Task<Students> UpdateStudentsAsync(Students Students); // PUT Students
        Task<(bool, string)> DeleteStudentsAsync(Students Students); // DELETE Students

        // Course Services
        Task<List<Courses>> GetCoursesAsync(); // GET All Courses
        Task<Courses> GetCourseAsync(Guid id); // GET Single Course
        Task<Courses> AddCourseAsync(Courses course); // POST New Course
        Task<Courses> UpdateCourseAsync(Courses course); // PUT Course
        Task<(bool, string)> DeleteCourseAsync(Courses course); // DELETE Course

        // StudentsCourse Services
        Task<List<StudentCourses>> GetStudentsCoursesAsync(); // GET All StudentsCourses
        Task<StudentCourses> GetStudentsCourseAsync(Guid studentId, Guid courseId); // GET Single StudentCourse
        Task<StudentCourses> AddStudentCourseAsync(StudentCourses studentCourse); // POST New StudentCourse
        Task<StudentCourses> UpdateStudentCourseAsync(StudentCourses studentCourse); // PUT StudentCourse
        Task<(bool, string)> DeleteStudentCourseAsync(StudentCourses studentCourse); // DELETE StudentCourse
        Task<ActionResult<IEnumerable<Students>>> GetStudentsAsync();
    }
}
