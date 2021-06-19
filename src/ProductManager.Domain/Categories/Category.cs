using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManager.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int MinStockQuantity { get; set; }

        protected Category()
        {
            // for serialization and deserialization 
        }

        public Category(Guid id, [NotNull] string name, int minStockQuantity) : base(id)
        {
            Name = Check.NotNullOrEmpty(name, nameof(name), CategoryConsts.MaxNameLength);
            MinStockQuantity = minStockQuantity;
        }
    }
}