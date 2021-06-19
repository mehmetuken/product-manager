using System;
using Volo.Abp.Application.Services;

namespace ProductManager.Products
{
    public interface IProductAppService : ICrudAppService<
        ProductDto,
        Guid,
        GetProductsInput,
        CreateUpdateProductDto>
    {
    }
}