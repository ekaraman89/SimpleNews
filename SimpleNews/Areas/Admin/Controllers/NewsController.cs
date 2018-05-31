using Newtonsoft.Json;
using SimpleNews.Areas.Admin.ViewModels;
using SimpleNews.Helpers;
using SimpleNews.Infrastructure;
using SimpleNews.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNews.Areas.Admin.Controllers
{
    [SelectedTab("News")]
    [Authorize]
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            return View(new NewsIndex { News = Database.Session.Query<News>().ToList() });
        }

        public ActionResult New(int? ID)
        {
            if (ID != null)
            {
                News news = Database.Session.Get<News>(ID);
                if (news != null)
                {
                    NewsNew newsNew = new NewsNew
                    {
                        Title = news.Title,
                        Body = news.Body,
                        Summary = news.Summary,
                        SeoLink = news.SeoLink,
                        CategoryID = news.CategoryID
                    };
                    return View(newsNew);
                }
            }
            return View(new NewsNew());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(NewsNew newsNew, HttpPostedFileBase image, int? ID)
        {
            if (Database.Session.Query<News>().Any(x => (x.SeoLink.Equals(newsNew.SeoLink)) && (x.ID != ID)))
                ModelState.AddModelError("", "SeoLink adı kullanılıyor");

            if (!ModelState.IsValid)
                return View(newsNew);

            News news = new News
            {
                Title = newsNew.Title,
                Body = newsNew.Body,
                Summary = newsNew.Summary,
                SeoLink = newsNew.SeoLink,
                CategoryID = newsNew.CategoryID,
                CoverPhoto = FileUpload.FileName(image, FileUpload.UploadFolder.News)
            };

            if (ID == null)
            {
                Database.Session.Save(news);
            }
            else
            {
                news.ID = (int)ID;
                Database.Session.Update(news);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public string Delete(int ID)
        {
            string message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Haber Silinemedi" });

            News news = Database.Session.Get<News>(ID);
            if (news != null)
            {
                Database.Session.Delete(news);
                message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Haber Silindi" });
            }
            return message;
        }
    }
}