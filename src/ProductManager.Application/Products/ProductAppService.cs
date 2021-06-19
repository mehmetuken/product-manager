using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProductManager.Products
{
    public class ProductAppService : CrudAppService<
            Product,
            ProductDto,
            Guid,
            GetProductsInput,
            CreateUpdateProductDto>,
        IProductAppService
    {
        private readonly ProductManager _productManager;

        public ProductAppService(
            IRepository<Product, Guid> repository,
            ProductManager productManager) : base(repository)
        {
            _productManager = productManager;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductsInput input)
        {
            var products = await _productManager.GetAllProducts(input.Query, input.MinQuantity, input.MaxQuantity);
            var productDtos = ObjectMapper.Map<IEnumerable<Product>, IReadOnlyList<ProductDto>>(products);
            return new PagedResultDto<ProductDto>(productDtos.Count, productDtos);
        }
    }
}