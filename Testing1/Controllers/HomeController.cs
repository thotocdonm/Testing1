using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Testing1.Models;

namespace Testing1.Controllers
{
    public class HomeController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["Testing1ConnectionString1"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var users = db.Users.ToList();  // Retrieve all users from the database
            return View(users);  // Pass the users list to the view
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}