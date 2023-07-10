using Microsoft.EntityFrameworkCore;
using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;

namespace PracticalTwenty.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _db;

        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDBContext db)
        {
            _db = db;
            dbSet = db.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            dbSet.Remove(await GetById(id));
            return true;
        }
    }
}
