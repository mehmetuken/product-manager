using System;
using Volo.Abp.Application.Dtos;

namespace ProductManager.Categories
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public int MinStockQuantity { get; set; }
    }
}