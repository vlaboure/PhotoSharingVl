using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharingVl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PhotoRoute",
                url: "{Photo}/{id}",
                defaults: new { controller = "Photo", action = "Display" }, constraints: new { id = "[0-9]+"}
            );
            routes.MapRoute(
                name: "PhotoTitleRoute",
                url: "{Photo}/title/{title}",
                defaults: new { controller = "Photo", action = "DisplayByTitle"} 
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
