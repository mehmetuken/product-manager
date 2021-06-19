using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ProductManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProductManagerEntityFrameworkCoreModule)
        )]
    public class ProductManagerEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProductManagerMigrationsDbContext>();
        }
    }
}
