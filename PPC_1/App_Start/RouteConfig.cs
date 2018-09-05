﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PPC_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cadastro_de_Curso",
                url: "Cadastro_de_Curso",
                defaults: new { controller = "Home", action = "Cadastro_de_Curso", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ConsultarCurso",
                url: "ConsultarCurso",
                defaults: new { controller = "Home", action = "ConsultarCurso", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
