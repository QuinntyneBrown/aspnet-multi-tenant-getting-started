using Chloe.Server.Config;
using Chloe.Server.Config.Contracts;
using Chloe.Server.Data;
using Chloe.Server.Data.Contracts;
using Chloe.Server.Services;
using Chloe.Server.Services.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Chloe.Server
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer(bool useMock = false) 
        {

            var container = new UnityContainer()
                .AddNewExtension<Interception>();

            container.RegisterType<IChloeUow, ChloeUow>();
            container.RegisterType<IDbContext, ChloeContext>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<ITenantService, TenantService>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IConfigurationProvider, ConfigurationProvider>();
            
            return container;
        }

    }
}