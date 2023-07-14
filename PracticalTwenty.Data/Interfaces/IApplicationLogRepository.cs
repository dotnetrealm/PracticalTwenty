using PracticalTwenty.Data.Models;

namespace PracticalTwenty.Data.Interfaces
{
    public interface IApplicationLogRepository
    {
        Task Insert(ApplicationLog entity);
    }
}
