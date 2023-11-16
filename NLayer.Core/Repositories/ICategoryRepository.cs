using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
