﻿using System.ComponentModel.DataAnnotations;

namespace BTWebAPI_1.Models
{
    public class Courses
    {
        [Key]
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
