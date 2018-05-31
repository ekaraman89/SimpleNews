using SimpleNews.ViewModels;
using System;
using System.Collections.Generic;
using SimpleNews.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleNews.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(login);

            User user = Database.Session.Query<User>().SingleOrDefault(x => x.Mail.Equals(login.Mail) && x.Password.Equals(login.Password));
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    return Redirect(ReturnUrl);
                return RedirectToRoute("Home");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }
    }
}