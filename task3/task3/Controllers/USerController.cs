using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task3.Controllers
{
    public class USerController : Controller
    {
        public IActionResult Profile()
        {
            ViewBag.useremail = HttpContext.Session.GetString("useremail");
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult HandelLogin(string email, string password)
        {
            //string Email = "_email";
            //string Password = "_password";


            if (email == "user@gmail.com" && password == "123")
            {
                HttpContext.Session.SetString("useremail",email);
                HttpContext.Session.SetString("userpassword", password);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["ErrorMesage"] = "Invalide user name or password";
                return RedirectToAction("Login");
            }
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult HandelRegister(string email, string password)
        {
            //string Email = "_email";
            //string Password = "_password";


            if (email == "user@gmail.com" && password == "123")
            {
                HttpContext.Session.SetString("useremail", email);
                HttpContext.Session.SetString("userpassword", password);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["ErrorMesage"] = "Invalide user name or password";
                return RedirectToAction("Login");
            }
        }

    }
}
