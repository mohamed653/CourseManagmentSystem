using CourseApp.Models;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoursesDbContext _context;
        public HomeController(CoursesDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCourses()
        {
            var courses = _context.Courses.ToList();
            
            return View(courses);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}