using ObjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UserInterface.Areas.Common.Controllers
{
    public class HomeController : Controller
    {
        MvcCRUDDB1Context db = new MvcCRUDDB1Context();
        // GET: Common/Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User_Login user)
        {
            var count = db.User_Login.Where(x => x.Username == user.Username && x.Password == user.Password).Count();
            if (count > 0)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Employee", new { area = "User" });
            }
            else
            {
                TempData["ErrorMsg"] = "User is not Valid";
                return View();
            }



        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });

        }
    }
}