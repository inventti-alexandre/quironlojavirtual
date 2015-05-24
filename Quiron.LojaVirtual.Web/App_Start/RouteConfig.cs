using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1- inicio sem pagina
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { 
                    controller = "Vitrine", 
                    action = "ListaProdutos",
                    categoria = (string) null, pagina = 1}
                );

            // 2 - sem categoria e com pagina
            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = @"\d+"
                });

            // 3 - com categoria sem pagina
            routes.MapRoute(
                name: null,
                url: "{categoria}",
                defaults: new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                });

            // 4 - com categoria e pagina
            routes.MapRoute(
                name: null,
                url: "{categoria}/Pagina{pagina}",
                defaults: new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = @"\d+"
                });

            // default MVC
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
