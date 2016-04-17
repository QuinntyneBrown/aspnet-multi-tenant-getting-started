using Chloe.Server.Models;

namespace Chloe.Server.Data.Contracts
{
    public interface IChloeUow
    {
        IRepository<Article> Articles { get; }
        IRepository<Tenant> Tenants { get; }

        void SaveChanges();
    }
}
