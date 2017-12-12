using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Text;

namespace Codifico.SemiSenior
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",

                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters[0].SupportedEncodings.Clear();
            config.Formatters[0].SupportedEncodings.Add(Encoding.GetEncoding(437));

        }
    }
}