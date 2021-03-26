using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FiltersMVC.Models;

namespace FiltersMVC.Controllers
{
    // Фільтри
    // Аутентифікації
    // Авторизації
    // Фільтри виключення
    // Action filter
    // Result filter


    [HandleError(View = "CustomError")]
    public class HomeController : Controller
    {
        private readonly Random random = new Random();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            if (user.Password == "1" && (user.Login == "admin" || user.Login == "user"))
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
                return RedirectToAction("Index");
            }

            return new HttpUnauthorizedResult();
        }

        [Authorize]
        public string TestFilter()
        {
            return $"Hello {User.Identity.Name}";
        }

        public string TestException()
        {
            var number = new Random().Next(6);
            if (number > 3)
            {
                throw new ArgumentException($"The number {number} should be less 3");
            }

            return "Everything is OK";
        }

        [CustomActionFilter]
        public string TestAction()
        {
            //  Thread.Sleep(3000);
            return "Work in action";
        }



        public ActionResult GetInfo()
        {
            var states = new[] { "Pending", "New", "In Progress", "Closed", "Canceled" };
            var state = states[random.Next(states.Length)];
            return Json(new { result = state }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Json(new HttpStatusCodeResult(HttpStatusCode.OK));
        }
    }
}