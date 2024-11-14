using DemoGenericRepositoryPattern.Data;
using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
namespace DemoGenericRepositoryPattern.Repositories
{
    // ProductRepository.cs
    public class ProductRepository(AppDbContext _context) : Repository<Product>(_context),IProductRepository
    {
        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await DbContext.Products.Take(5).ToListAsync();
        }
    }

}
