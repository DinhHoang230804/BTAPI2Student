using BTWebAPI_1.Data;
using BTWebAPI_1.Models;
using BTWebAPI_1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTWebAPI_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILibraryService _schoolService;

        public StudentController(ILibraryService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _schoolService.GetStudentssAsync();
            if (students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No students in database.");
            }

            return StatusCode(StatusCodes.Status200OK, students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _schoolService.GetStudentsAsync(id);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No student found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }

        [HttpPost]
        public async Task<ActionResult<Students>> AddStudent(Students student)
        {
            var dbStudent = await _schoolService.AddStudentsAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be added.");
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, Students student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            var dbStudent = await _schoolService.UpdateStudentsAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _schoolService.GetStudentsAsync(id);
            var (status, message) = await _schoolService.DeleteStudentsAsync(student);

            if (!status)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }
    }
}
