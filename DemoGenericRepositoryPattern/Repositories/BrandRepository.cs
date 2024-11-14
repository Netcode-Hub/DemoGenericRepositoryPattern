using DemoGenericRepositoryPattern.Data;
using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoGenericRepositoryPattern.Repositories
{
    // BrandRepository.cs
    public class BrandRepository(AppDbContext _context) :Repository<Brand>(_context), IBrandRepository
    {
        public async Task<IEnumerable<Brand>> GetListAsync()
        {
            return await DbContext.Brands.Take(3).ToListAsync();
        }
    }

}
