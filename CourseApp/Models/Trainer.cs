using System;
using System.Collections.Generic;

namespace CourseApp.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
