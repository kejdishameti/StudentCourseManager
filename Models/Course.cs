using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace StudentCourseManager.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
