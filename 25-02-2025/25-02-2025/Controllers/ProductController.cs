using _25_02_2025.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _25_02_2025.Controllers
{
    public class ProductController : Controller
    {

        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }



        public IActionResult Home()
        {
            return View(_context.Products.ToList());
        }


        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Users.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detalies(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
    }
}
