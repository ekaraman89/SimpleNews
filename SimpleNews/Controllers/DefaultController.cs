using SimpleNews.Areas.Admin.ViewModels;
using SimpleNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNews.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            NewsIndex newsIndex = new NewsIndex { News = Database.Session.Query<News>().ToList() };
            return View(newsIndex);
        }

        public ActionResult GetCategories()
        {
            CategoriesIndex categoriesIndex = new CategoriesIndex
            {
                Categories = Database.Session.Query<Category>().ToList()
            };

            return View(categoriesIndex);
        }

        public ActionResult GetLastNews()
        {
            return View();
        }

        public ActionResult ShowNews(string seo_link)
        {
            News news = Database.Session.Query<News>().SingleOrDefault(x => x.SeoLink.Equals(seo_link));
            if (news != null)
            {
                NewsNew newsNew = new NewsNew
                {
                    Title = news.Title,
                    Body = news.Body,
                    Summary = news.Summary,
                    SeoLink = news.SeoLink,
                    CoverPhoto = news.CoverPhoto,
                    CategoryID = news.CategoryID
                };
                return View(newsNew);
            }
            return RedirectToRoute("Home");
        }

        public ActionResult CategoryOfNews(string CategoryName)
        {
            Category category = Database.Session.Query<Category>().SingleOrDefault(x => x.CategoryName.Equals(CategoryName));
            if (category == null)
                return RedirectToRoute("Home");
            NewsIndex newsIndex = new NewsIndex { News = Database.Session.Query<News>().Where(x => x.CategoryID.Equals(category.ID)).ToList() };
            return View(newsIndex);
        }


    }
}