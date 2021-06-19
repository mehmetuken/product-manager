using Volo.Abp.Application.Dtos;

namespace ProductManager.Products
{
    public class GetProductsInput : PagedAndSortedResultRequestDto
    {
        public string Query { get; set; }

        public int? MinQuantity { get; set; }

        public int? MaxQuantity { get; set; }
    }
}