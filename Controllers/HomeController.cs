using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using UserAdding.Models;

namespace UserAdding.Controllers
{
    public class HomeController : Controller
    {

        UsersContext usersContext = new UsersContext();
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            ViewBag.Users = usersContext.GetUsers();

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            usersContext.AddUser(user);
            List<User> users=usersContext.GetUsers().ToList();
            return PartialView(users);
        }
        
    }
}
