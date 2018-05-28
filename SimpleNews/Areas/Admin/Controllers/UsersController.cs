using SimpleNews.Areas.Admin.ViewModels;
using SimpleNews.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SimpleNews.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Index()
        {
            return View(new UsersIndex { Users = Database.Session.Query<User>().ToList() });
        }
    }
}