using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperTest.Models;
using DeveloperTest.Service;

namespace DeveloperTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService = new HomeService();
        public ActionResult Login()
        {
            return View();
        }

        public JsonResult LoginCheck(string Uname, string Password)
        {
            var result = _homeService.Login(Uname, Password);
            if (result == 0)
            {
                return new JsonResult { Data = new { Status = "AuthenticationFailed", msg = "Invalid Email  Id or Password" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                Session["UserId"] = result;                                
                return new JsonResult { Data = new { Status = "Success"}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}