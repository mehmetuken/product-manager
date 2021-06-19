using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ProductManager.EntityFrameworkCore
{
    public static class ProductManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureProductManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ProductManagerConsts.DbTablePrefix + "YourEntities", ProductManagerConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}