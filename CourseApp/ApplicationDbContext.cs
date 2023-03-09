using Microsoft.EntityFrameworkCore;

namespace CourseApp
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}
