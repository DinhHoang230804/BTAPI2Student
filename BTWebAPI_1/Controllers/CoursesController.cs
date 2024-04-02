using BTWebAPI_1.Models;
using BTWebAPI_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTWebAPI_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILibraryService _schoolService;

        public CoursesController(ILibraryService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _schoolService.GetCoursesAsync();
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No courses in database.");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            Courses course = await _schoolService.GetCourseAsync(id);

            if (course == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No course found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddCourse(Courses course)
        {
            var dbCourse = await _schoolService.AddCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, Courses course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            Courses dbCourse = await _schoolService.UpdateCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _schoolService.GetCourseAsync(id);
            (bool status, string message) = await _schoolService.DeleteCourseAsync(course);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }
    }
}
