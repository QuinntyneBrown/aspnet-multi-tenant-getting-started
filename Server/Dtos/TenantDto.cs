using Chloe.Server.Models;

namespace Chloe.Server.Dtos
{
    public class TenantDto
    {
        public TenantDto(Tenant entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public TenantDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
