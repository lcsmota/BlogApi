using System.Linq.Expressions;
using BlogApi.Context;
using BlogApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly BlogDbContext _context;
    public GenericRepository(BlogDbContext context)
    {
        _context = context;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity); ;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public async Task InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
}
