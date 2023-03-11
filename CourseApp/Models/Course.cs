using System;
using System.Collections.Generic;

namespace CourseApp.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseLessons = new HashSet<CourseLesson>();
            TraineeCourses = new HashSet<TraineeCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int? TrainerId { get; set; }
        public string? Video { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Trainer? Trainer { get; set; }
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
        public virtual ICollection<TraineeCourse> TraineeCourses { get; set; }
    }
}
