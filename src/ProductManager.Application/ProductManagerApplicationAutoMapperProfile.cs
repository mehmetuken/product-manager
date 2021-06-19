using AutoMapper;
using ProductManager.Categories;
using ProductManager.Products;

namespace ProductManager
{
    public class ProductManagerApplicationAutoMapperProfile : Profile
    {
        public ProductManagerApplicationAutoMapperProfile()
        {
            CreateMap<Category,CategoryDto>();
            CreateMap<CreateUpdateCategoryDto, Category>();
            
            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto,Product>();
        }
    }
}
