using System;
using System.Collections.Generic;

namespace CourseApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
            InverseParent = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
