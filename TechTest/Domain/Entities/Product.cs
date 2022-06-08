using Domain.Common;
using Domain.Events;

namespace Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
