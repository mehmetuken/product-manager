using System;
using JetBrains.Annotations;
using ProductManager.Categories;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManager.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; }

        public string Description { get; set; }

        [CanBeNull]
        public Category Category { get; set; }

        public Guid? CategoryId { get; set; }

        public int StockQuantity { get; set; }

        protected Product()
        {
            // for serialization and deserialization 
        }

        public Product(Guid id,[NotNull] string title, int stockQuantity) : base(id)
        {
            Title = Check.NotNullOrEmpty(title,nameof(title), ProductConsts.MaxNameLength);
            StockQuantity = stockQuantity;
        }
    }
}