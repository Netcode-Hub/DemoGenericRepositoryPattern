using DemoGenericRepositoryPattern.Models;

namespace DemoGenericRepositoryPattern.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetListAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
