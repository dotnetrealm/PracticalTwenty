using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;

namespace PracticalTwenty.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly ApplicationDBContext _db;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Users = new UserRepository(_db);
        }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync("Admin");
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
