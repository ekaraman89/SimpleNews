using Newtonsoft.Json;
using SimpleNews.Areas.Admin.ViewModels;
using SimpleNews.Infrastructure;
using SimpleNews.Models;
using System.Linq;
using System.Web.Mvc;

namespace SimpleNews.Areas.Admin.Controllers
{
    [SelectedTab("Users")]
    [Authorize]
    public class UsersController : Controller
    {

        public ActionResult Index()
        {
            return View(new UsersIndex { Users = Database.Session.Query<User>().ToList() });
        }

        public ActionResult New(int? ID)
        {
            if (ID != null)
            {
                User user = Database.Session.Get<User>(ID);
                if (user != null)
                {
                    UsersNew usersNew = new UsersNew
                    {
                        Mail = user.Mail,
                        Password = user.Password,
                        Surname = user.Surname,
                        UserName = user.UserName
                    };
                    return View(usersNew);
                }
            }
            return View(new UsersNew());
        }

        [HttpPost]
        public ActionResult New(UsersNew usersNew, int? ID)
        {
            if (Database.Session.Query<User>().Any(u => (u.UserName.Equals(usersNew.UserName) || u.Mail.Equals(usersNew.Mail)) && (u.ID != ID)))
                ModelState.AddModelError("", "Kullanıcı adı veya mail adresi kullanılıyor");

            if (!ModelState.IsValid)
                return View(usersNew);

            User user = new User
            {
                Mail = usersNew.Mail,
                UserName = usersNew.UserName,
                Surname = usersNew.Surname,
                Password = usersNew.Password
            };


            if (ID == null)
            {
                Database.Session.Save(user);
            }
            else
            {
                user.ID = (int)ID;
                Database.Session.Update(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int ID)
        {
            string message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Kullanıcı Silinemedi" });

            User user = Database.Session.Get<User>(ID);
            if (user != null)
            {
                Database.Session.Delete(user);
                message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Kullanıcı Silindi" });
            }
            return message;
        }
    }
}