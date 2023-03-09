using System;
using System.Collections.Generic;

namespace CourseApp.Models;

public partial class Trainee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<TraineeCourse> TraineeCourses { get; } = new List<TraineeCourse>();
}
