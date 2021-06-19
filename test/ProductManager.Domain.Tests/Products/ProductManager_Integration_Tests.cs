using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ProductManager.Products
{
    public class ProductManager_Integration_Tests : ProductManagerDomainTestBase
    {
        private readonly ProductManager _productManager;

        public ProductManager_Integration_Tests()
        {
            _productManager = GetRequiredService<ProductManager>();
        }

        [Fact]
        public async Task Should_Not_Live_Products_Count()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var products = await _productManager.GetAllProducts();
                products.Count().ShouldBe(2);
            });
        }
    }
}