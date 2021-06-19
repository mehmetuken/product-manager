using System;
using System.Threading.Tasks;
using ProductManager.Categories;
using ProductManager.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace ProductManager
{
    public class ProductManagerDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductManagerDataSeederContributor(IRepository<Category, Guid> categoryRepository,
            IGuidGenerator guidGenerator, IRepository<Product, Guid> productRepository)
        {
            _guidGenerator = guidGenerator;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() > 0)
            {
                return;
            }

            var tireCategory = await _categoryRepository.InsertAsync(
                new Category(_guidGenerator.Create(), "Lastik", 5),
                autoSave: true
            );

            var rimCategory = await _categoryRepository.InsertAsync(
                new Category(_guidGenerator.Create(), "Jant", 10),
                autoSave: true
            );

            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Goodyear 205/55 R16 91V Eagle Sport Oto Yaz Lastiği ( Üretim Yılı: 2021 )", 5),
                true
            );

            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Goodyear 185/65 R15 88H Eagle Sport Oto Yaz Lastiği ( Üretim Yılı: 2021 )", 4)
                {
                    CategoryId = tireCategory.Id
                },
                true
            );
            
            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Michelin 205/55 R16 91V Primacy 4 Oto Yaz Lastiği ( Üretim Yılı: 2021 )", 3)
                {
                    CategoryId = tireCategory.Id
                },
                true
            );
            
            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Kormetal DY288-2 Gmd Z-DY28 Seri 9,0X18 Pcd 5X112 Et 48 ( 4 Adet )", 7)
                {
                    CategoryId = rimCategory.Id
                },
                true
            );
            
            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Powcan BK-495 7*16 5X120 ET35 72.56 Hyp.sılver", 54)
                {
                    CategoryId = rimCategory.Id
                },
                true
            );
            
            await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    "Kormetal 5X108 Kormetal KM875", 43)
                {
                    CategoryId = rimCategory.Id
                },
                true
            );
        }
    }
}