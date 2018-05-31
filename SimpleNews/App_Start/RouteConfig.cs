using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleNews
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Home", "", new { controller = "Default", action = "Index" });
            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Index" });
            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });

        }
    }
}
