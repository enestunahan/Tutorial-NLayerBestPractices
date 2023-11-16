using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            // Buna eager loading diyoruz yani productları alırken birde categoryleri alma olayına , birde lazy loading var
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
