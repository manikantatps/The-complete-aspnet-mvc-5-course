using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Custom route for movies controller
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { Controller = "Movies", Action = "ByReleaseDate" },
            //    new { year = @"\d{4}", month = @"\d{2}" });
            //this will accept only year as 2015 or 2016
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { Controller = "Movies", Action = "ByReleaseDate" },
            //    new { year = @"2015|2016", month = @"\d{2}" });

            //If we write "MapMvcAttributeRoutes" we can write route in controller itself instead of in RouteConfig.cs file
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
