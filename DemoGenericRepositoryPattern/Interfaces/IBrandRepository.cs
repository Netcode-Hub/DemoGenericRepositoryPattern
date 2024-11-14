
using DemoGenericRepositoryPattern.Models;

namespace DemoGenericRepositoryPattern.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetListAsync();
        Task<Brand> GetByIdAsync(int id);
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(int id);
    }
}
