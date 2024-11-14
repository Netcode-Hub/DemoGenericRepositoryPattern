using DemoGenericRepositoryPattern.Data;

namespace DemoGenericRepositoryPattern.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext DbContext;
        protected Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var model = await DbContext.FindAsync<TEntity>(id);
            return model!;
        }
        public async Task DeleteAsync(int id)
        {
            var model = await DbContext.FindAsync<TEntity>(id);
            DbContext.Set<TEntity>().Remove(model!);
            await DbContext.SaveChangesAsync();
        }
    }
}
