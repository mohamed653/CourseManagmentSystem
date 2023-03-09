using System;
using System.Collections.Generic;

namespace CourseApp.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int? TrainerId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CourseLesson> CourseLessons { get; } = new List<CourseLesson>();

    public virtual ICollection<TraineeCourse> TraineeCourses { get; } = new List<TraineeCourse>();

    public virtual Trainee? Trainer { get; set; }

    public virtual Trainer? TrainerNavigation { get; set; }
}
