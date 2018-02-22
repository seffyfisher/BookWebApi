using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //global cors
            var corsRules = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsRules);

            //return json to browser as well
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
