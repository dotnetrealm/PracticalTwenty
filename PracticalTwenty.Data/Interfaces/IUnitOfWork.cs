namespace PracticalTwenty.Data.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// All repositories
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Single point to commit changes to DB
        /// </summary>
        Task CompleteAsync();
    }
}
