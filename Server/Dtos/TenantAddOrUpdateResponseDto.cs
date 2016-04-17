using Chloe.Server.Models;

namespace Chloe.Server.Dtos
{
    public class TenantAddOrUpdateResponseDto: TenantDto
    {
        public TenantAddOrUpdateResponseDto(Tenant entity)
            :base(entity)
        {

        }
    }
}
