using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing1.Models;

namespace Testing1.Controllers
{
    public class AdminController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["Testing1ConnectionString1"].ConnectionString);
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if user exists in the database
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Store user info in session
                    Session["UserId"] = user.UserId;
                    Session["Username"] = user.Username;

                    // Redirect to the homepage or another secured page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();  // Clear session
            return RedirectToAction("Login", "Admin");
        }
    }
}