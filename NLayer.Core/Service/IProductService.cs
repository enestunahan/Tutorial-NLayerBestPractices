using NLayer.Core.Dtos;
using NLayer.Core.Models;

namespace NLayer.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync();
    }
}
