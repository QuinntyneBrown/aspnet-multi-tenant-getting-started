using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using static Chloe.Server.UnityConfiguration;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
using Chloe.Server.Services.Contracts;

namespace Chloe.Server.Middleware
{   
    public class TenantMiddleware
    {
        AppFunc _next;

        public TenantMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var tenant = GetContainer().Resolve<ITenantService>().GetByUri((string)environment["Request.Uri.Host"]);
            environment.Add("MultiTenant", tenant);
            await _next.Invoke(environment);
        }
    }
}