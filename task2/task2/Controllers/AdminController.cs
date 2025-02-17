using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
