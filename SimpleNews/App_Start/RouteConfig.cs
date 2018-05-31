using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleNews
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Index" });
            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });

            routes.MapRoute("Home", "", new { controller = "Default", action = "Index" });
            routes.MapRoute("GetCategories", "GetCategories", new { controller = "Default", action = "GetCategories" });

            routes.MapRoute("ShowNews", "Show/{seo_link}", new { controller = "Default", action = "ShowNews" });
            routes.MapRoute("CategoryOfNews", "Category/{CategoryName}", new { controller = "Default", action = "CategoryOfNews" });


        }
    }
}
