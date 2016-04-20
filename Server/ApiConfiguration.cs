using Chloe.Server.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using Microsoft.Practices.Unity;
using static Chloe.Server.UnityConfiguration;
using Chloe.Server.Middleware;
using Chloe.Server.Extensions;

namespace Chloe.Server
{    
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            app.UseTenantMiddleware();

            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}