using Microsoft.EntityFrameworkCore;
using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Models;

namespace PracticalTwenty.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context) { }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public override async Task<User> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public override async Task<bool> Insert(User entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(u => u.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser == null) return await Insert(entity);

                existingUser.Firstname = entity.Firstname;
                existingUser.LastName = entity.LastName;
                existingUser.Password = entity.Password;
                existingUser.Email = entity.Email;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async override Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.FirstOrDefaultAsync(u => u.Id == id);
                if (exist == null) { return false; }
                dbSet.Remove(exist);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
