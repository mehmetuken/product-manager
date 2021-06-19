using Microsoft.EntityFrameworkCore;
using ProductManager.Categories;
using ProductManager.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ProductManager.EntityFrameworkCore
{
    public static class ProductManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureProductManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Category>(b =>
            {
                b.ToTable(ProductManagerConsts.DbTablePrefix + "Categories", ProductManagerConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                
                b.Property(x => x.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength);
            });
            
            builder.Entity<Product>(b =>
            {
                b.ToTable(ProductManagerConsts.DbTablePrefix + "Products", ProductManagerConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                
                b.Property(x => x.Title).IsRequired().HasMaxLength(ProductConsts.MaxNameLength);
                b.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
            });
        }
    }
}