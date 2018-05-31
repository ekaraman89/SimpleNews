using Newtonsoft.Json;
using SimpleNews.Areas.Admin.ViewModels;
using SimpleNews.Infrastructure;
using SimpleNews.Models;
using System.Linq;
using System.Web.Mvc;

namespace SimpleNews.Areas.Admin.Controllers
{
    [SelectedTab("Category")]
    [Authorize]
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return View(new CategoriesIndex { Categories = Database.Session.Query<Category>().ToList() });
        }

        public ActionResult New(int? ID)
        {
            if (ID != null)
            {
                Category category = Database.Session.Get<Category>(ID);
                if (category != null)
                {
                    CategoriesNew categoriesNew = new CategoriesNew
                    {
                        CategoryName = category.CategoryName
                    };
                    return View(categoriesNew);
                }
            }
            return View(new CategoriesNew());
        }

        [HttpPost]
        public ActionResult New(CategoriesNew categoriesNew, int? ID)
        {
            if (Database.Session.Query<Category>().Any(x => (x.CategoryName.Equals(categoriesNew.CategoryName)) && (x.ID != ID)))
                ModelState.AddModelError("", "Kategori adı kullanılıyor");

            if (!ModelState.IsValid)
                return View(categoriesNew);

            Category category = new Category
            {
                CategoryName = categoriesNew.CategoryName,
            };


            if (ID == null)
            {
                Database.Session.Save(category);
            }
            else
            {
                category.ID = (int)ID;
                Database.Session.Update(category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int ID)
        {
            string message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Kategori Silinemedi" });

            Category category = Database.Session.Get<Category>(ID);
            if (category != null)
            {
                Database.Session.Delete(category);
                message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Kategori Silindi" });
            }
            return message;
        }
    }
}