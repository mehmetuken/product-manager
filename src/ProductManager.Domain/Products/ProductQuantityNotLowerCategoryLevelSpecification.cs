using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace ProductManager.Products
{
    public class ProductQuantityNotLowerCategoryLevelSpecification : Specification<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => p.StockQuantity >= p.Category.MinStockQuantity;
        }
    }
}