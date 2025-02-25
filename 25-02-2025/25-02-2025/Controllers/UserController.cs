using _25_02_2025.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _25_02_2025.Controllers
{
    public class UserController : Controller
    {

        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: UserController
        public IActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult UserInfo()
        {
            var userInfo = _context.Users.FirstOrDefault(user => user.RoleType == "user");
            return View(userInfo);
        }

        // GET: UserController/Create //Register
        public ActionResult Create()
        {
            return View();
        }



        public IActionResult userData()
        {
            return View();
        }

        // POST: UserController/Create  //Registerhandling
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                user.RoleType = "user";
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View(user);
                //return Unauthorized();
            }
        }



        // GET: UserController/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            string Email = Request.Form["email"];
            string Password = Request.Form["password"];

            // Find user from the database
            var userInfo = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (userInfo != null) // If user is found
            {
                // Store user details in session
                HttpContext.Session.SetString("useremail", userInfo.Email);
                HttpContext.Session.SetString("username", userInfo.Name);
                HttpContext.Session.SetString("userrole", userInfo.RoleType);

                // Redirect based on role
                if (userInfo.RoleType == "user")
                {
                    return RedirectToAction("Home", "Product");
                }
                else
                {
                    return RedirectToAction("Admin"); 
                }
            }
            else
            {
                TempData["ErrorMesage"] = "Invalid email or password.";
                return RedirectToAction("Login");
            }
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var userInfo = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            //        if (userInfo.RoleType == "user")
            //        {
            //            return RedirectToAction("Home", "Product");

            //        }
            //        else
            //        {
            //            return RedirectToAction(nameof(Admin));

            //        }
            //    }
            //    else
            //    {
            //        return View(user);

            //    }
        }


        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult user()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }


        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }










        ///BY Adminnnnnnnnnnnnn







        // List of Users
        public ActionResult LisrOfUsers()
        {
            return View(_context.Users.ToList());
        }

        // GET: UserController/Create //Register
        public ActionResult AdminCreate()
        {
            return View();
        }
        // POST: UserController/Create  //Registerhandling
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreate(User user)
        {

            if (ModelState.IsValid)
            {
                user.RoleType = "user";
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(user);
                //return Unauthorized();
            }
        }

        // GET: UserController/EditbyAdmin/5
        public ActionResult EditAdmin(int id)
        {
            return View();
        }

        // POST: UserController/EditbyAdmin/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Admin));

        }


        public IActionResult Details()
        {
            var AdminInfo = _context.Users.FirstOrDefault(admin => admin.RoleType == "Admin");
            return View(AdminInfo);
        }


        public IActionResult Delete(int Id)
        {
            var user = _context.Users.Find(Id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Admin");

        }
    }
}
