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
            //var data = Request.Cookies["userInfo"];
            //if (data != null)
            //    return RedirectToAction("Index", "Home");
            //else
                return View();
        }


        [HttpPost]
        public IActionResult HandelLogin(string email, string password, string rememberme)
        {
            //task3
            string Email = Request.Form["email"];
            string Password = Request.Form["password"];
            bool rememberMe = Request.Form["rememberMe"] == "on";

            string stringEmailSession = HttpContext.Session.GetString("useremail");
                  string stringPasswordSession = HttpContext.Session.GetString("userpassword");

            if (Email == stringEmailSession && Password == stringPasswordSession)
            { 
                if (rememberMe)
            {
                CookieOptions cookieobj = new CookieOptions();
                cookieobj.Expires = DateTime.Now.AddDays(7);
                //store
                Response.Cookies.Append("useremail", Email, cookieobj);
                Response.Cookies.Append("userpassword", Password, cookieobj);
            }


           

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
        public IActionResult HandelRegister()
        {
            //string Email = "_email";
            //string Password = "_password";

           
                HttpContext.Session.SetString("useremail", Request.Form["email"]);
                HttpContext.Session.SetString("userpassword", Request.Form["password"]);
                HttpContext.Session.SetString("name", Request.Form["name"]);
            // return RedirectToAction("Index", "Home");
           // HttpContext.Session.CommitAsync();
            return RedirectToAction("Login");


        }

        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();

    
            Response.Cookies.Delete("useremail");
            Response.Cookies.Delete("userpassword");

            return RedirectToAction("Login");
        }

    }
}
