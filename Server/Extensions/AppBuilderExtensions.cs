using Chloe.Server.Middleware;
using Owin;

namespace Chloe.Server.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void UseTenantMiddleware(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Environment.Add("Request.Uri.Host", context.Request.Uri.Host);
                await next();
            });

            app.Use<TenantMiddleware>();
        }
    }
}