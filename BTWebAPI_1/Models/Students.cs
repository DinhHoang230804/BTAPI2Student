using System.ComponentModel.DataAnnotations;

namespace BTWebAPI_1.Models
{
    public class Students
    {
        [Key]
        public Guid StudentID { get; set; }
        public string Name { get; set;}

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
