using _23_02_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23_02_2025.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        } 
        public IActionResult Index()
        {
            return View(_context.Departments.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(Department dep)
        {

            _context.Add(dep);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
