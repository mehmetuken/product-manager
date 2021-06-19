using System;
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
        public ProductAppService(IRepository<Product, Guid> repository) : base(repository)
        {
        }
    }
}