using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Models;

namespace PracticalTwenty.Data.Repositories
{
    public class ApplicationLogRepository : IApplicationLogRepository
    {
        private readonly ApplicationDBContext _db;

        public ApplicationLogRepository(ApplicationDBContext context)
        {
            _db = context;
        }
        public async Task Insert(ApplicationLog entity)
        {
            _db.ApplicationLogs.Add(entity);
            await _db.SaveChangesAsync();
        }
    }
}
