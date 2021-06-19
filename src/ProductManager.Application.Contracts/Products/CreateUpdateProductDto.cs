using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Products
{
    public class CreateUpdateProductDto
    {
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public int StockQuantity { get; set; }
    }
}