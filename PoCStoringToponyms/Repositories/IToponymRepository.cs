public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task InsertAsync(T entity);
    Task InsertManyAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
