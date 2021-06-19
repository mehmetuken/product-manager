using System;
using ProductManager.Categories;
using Volo.Abp.Application.Dtos;

namespace ProductManager.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryDto Category { get; set; }

        public int StockQuantity { get; set; }
    }
}