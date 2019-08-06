using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnivCloud
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "LogIn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RedirectLogIn",
                url: "LogIn",
                defaults: new { controller = "Authentication", action = "LogIn", id = UrlParameter.Optional }
            );
        }
    }
}
