using System.ComponentModel.DataAnnotations;

namespace BTWebAPI_1.Models
{
    public class StudentCourses
    {
        [Key]
        public Guid Studentid { get; set; }
        public Guid CourseId { get; set; }

        public virtual Students Students { get; set; }
        public virtual Courses Courses { get; set; }
    }   
}
