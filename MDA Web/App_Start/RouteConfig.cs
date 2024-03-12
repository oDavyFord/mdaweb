using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MDA_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            //// RUTAS SIN HOME
            //routes.MapRoute(
            //    "Inicio",
            //    "inicio",
            //    new { controller = "Home", action = "Inicio" }
            //);
            //routes.MapRoute(
            //    "Beneficios",
            //    "beneficios",
            //    new { controller = "Home", action = "Beneficios" }
            //);
            //routes.MapRoute(
            //    "Alianzas",
            //    "alianzas",
            //    new { controller = "Home", action = "Alianzas" }
            //);
            //routes.MapRoute(
            //    "Contacto",
            //    "contacto",
            //    new { controller = "Home", action = "Contacto" }
            //);
            //routes.MapRoute(
            //    "Faq",
            //    "faq",
            //    new { controller = "Home", action = "Faq" }
            //);
            //routes.MapRoute(
            //    "Faq_02",
            //    "faq_02",
            //    new { controller = "Home", action = "Faq_02" }
            //);
            //routes.MapRoute(
            //    "Faq_03",
            //    "faq_03",
            //    new { controller = "Home", action = "Faq_03" }
            //);
            //routes.MapRoute(
            //    "Robo_Extravio",
            //    "robo_extravio",
            //    new { controller = "Home", action = "Robo_Extravio" }
            //);
            //routes.MapRoute(
            //    "Transferencia_Saldo",
            //    "transferencia_saldo",
            //    new { controller = "Home", action = "Transferencia_Saldo" }
            //);
            //routes.MapRoute(
            //    "Transferencia_Saldo_Tarjeta",
            //    "transferencia_saldo_tarjeta",
            //    new { controller = "Home", action = "Transferencia_Saldo_Tarjeta" }
            //);
            //routes.MapRoute(
            //    "Transferencia_Saldo_Datos",
            //    "transferencia_saldo_datos",
            //    new { controller = "Home", action = "Transferencia_Saldo_Datos" }
            //);
            //routes.MapRoute(
            //    "Transferencia_Saldo_Error",
            //    "transferencia_saldo_error",
            //    new { controller = "Home", action = "Transferencia_Saldo_Error" }
            //);
            //routes.MapRoute(
            //    "Transferencia_Saldo_Exito",
            //    "transferencia_saldo_exito",
            //    new { controller = "Home", action = "Transferencia_Saldo_Exito" }
            //);

            // RUTAS CON HOME
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
