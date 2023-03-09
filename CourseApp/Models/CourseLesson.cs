using System;
using System.Collections.Generic;

namespace CourseApp.Models;

public partial class CourseLesson
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CourseId { get; set; }

    public int? OrderNumber { get; set; }

    public virtual Course Course { get; set; } = null!;
}
