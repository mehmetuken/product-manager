using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ProductManager.Products
{
    public class ProductManager : DomainService
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductManager(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public virtual async Task<IEnumerable<Product>> GetAllProducts(
            string query,
            int? minStockCount = null,
            int? maxStockCount = null)
        {
            var queryable = await _productRepository.WithDetailsAsync(x => x.Category);

            // Global filter to products to be live.
            queryable = AddGlobalFilter(queryable);

            queryable = queryable.WhereIf(
                !string.IsNullOrEmpty(query),
                x => x.Title.Contains(query) || x.Description.Contains(query) ||
                     x.Category.Name.Contains(query)
            );

            queryable = queryable.WhereIf(minStockCount != null, m => m.StockQuantity > minStockCount);
            queryable = queryable.WhereIf(maxStockCount != null, m => m.StockQuantity < maxStockCount);

            return await AsyncExecuter.ToListAsync(queryable);
        }

        private IQueryable<Product> AddGlobalFilter(IQueryable<Product> queryable)
        {
            return queryable
                .Where(new ProductCategorySelectedSpefication().ToExpression())
                .Where(new ProductQuantityNotLowerCategoryLevelSpecification().ToExpression());
        }
    }
}