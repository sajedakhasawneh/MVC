using _23_02_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23_02_2025.Controllers
{
    public class UserController : Controller
    {

        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(User user)
        {

            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
