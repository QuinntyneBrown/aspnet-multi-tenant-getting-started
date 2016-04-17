using System;

namespace Chloe.Server.Exceptions
{
    public class TenantNotFoundException: NotFoundException
    {
        public TenantNotFoundException()
            :base("Tenant Not Found")
        {
        }

        public TenantNotFoundException(string message)
            :base(message)
        {

        }

        public TenantNotFoundException(string message, Exception inner)
        {

        }
    }
}
