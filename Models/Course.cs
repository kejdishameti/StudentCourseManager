using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace StudentCourseManager.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
