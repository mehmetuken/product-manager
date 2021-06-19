using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace ProductManager.Products
{
    public class ProductCategorySelectedSpefication : Specification<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => p.Category != null;
        }
    }
}