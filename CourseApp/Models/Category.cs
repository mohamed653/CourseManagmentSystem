using System;
using System.Collections.Generic;

namespace CourseApp.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ParentId { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<Category> InverseParent { get; } = new List<Category>();

    public virtual Category Parent { get; set; } = null!;
}
