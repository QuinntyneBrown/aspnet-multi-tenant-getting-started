using Chloe.Server.Dtos;
using Chloe.Server.Models;
using System.Collections.Generic;

namespace Chloe.Server.Services.Contracts
{
    public interface ITenantService
    {
        TenantAddOrUpdateResponseDto AddOrUpdate(TenantAddOrUpdateRequestDto request);
        ICollection<TenantDto> Get();
        TenantDto GetById(int id);
        dynamic Remove(int id);
        Tenant GetByUri(string uri);
    }
}
