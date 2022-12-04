using System.Linq.Expressions;

namespace BlogApi.Interfaces;
public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
    Task InsertAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
