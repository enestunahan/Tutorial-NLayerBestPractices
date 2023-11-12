using AutoMapper;
using NLayer.Core.Dtos;
using NLayer.Core.Models;

namespace NLayer.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeautureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
