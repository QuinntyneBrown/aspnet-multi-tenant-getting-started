using System.ComponentModel.DataAnnotations.Schema;

namespace Chloe.Server.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public string Name { get; set; }
        public Tenant Tenant { get; set; }
        public bool IsDeleted { get; set; }
    }
}