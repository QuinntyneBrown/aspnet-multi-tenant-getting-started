using Chloe.Server.Exceptions;
using Chloe.Server.Models;
using System.Web;
using System.Web.Http;

namespace Chloe.Server.Controllers
{
    public class BaseController: ApiController
    {
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if (!HttpContext.Current.GetOwinContext().Environment.TryGetValue("MultiTenant", out multiTenant))
                {
                    throw new TenantNotFoundException();
                }
                return (Tenant)multiTenant;
            }
        }
    }
}