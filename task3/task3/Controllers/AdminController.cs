using Microsoft.AspNetCore.Mvc;

namespace task3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
