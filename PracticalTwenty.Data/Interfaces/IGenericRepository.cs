namespace PracticalTwenty.Data.Interfaces
{
    /// <summary>
    /// Generic interface of repository for CRUD operation on any object of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Returns all data of type T
        /// </summary>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Return specific object of type T by it's id
        /// </summary>
        /// <param name="id">Id of type T</param>
        Task<T?> GetById(int id);

        /// <summary>
        /// Insert new object of type T
        /// </summary>
        /// <param name="entity">Object of type T</param>
        Task<bool> Insert(T entity);

        /// <summary>
        /// Update existing object of type T
        /// </summary>
        /// <param name="entity">object of type T</param>
        Task<bool> Update(T entity);

        /// <summary>
        /// Delete existing object of type T
        /// </summary>
        /// <param name="id">Id of object T</param>
        Task<bool> Delete(int id);
    }
}
