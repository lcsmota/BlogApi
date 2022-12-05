using BlogApi.Context;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly BlogDbContext _context;
    public BlogRepository(BlogDbContext context)
        : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Blog>> GetBlogWithPostsAsync()
    {
        return await _context.Blogs
                             .Include(e => e.Posts)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task<Blog> GetBlogWithPostsByIdAsync(int id)
    {
        return await _context.Blogs
                             .Include(e => e.Posts)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => p.BlogId == id);
    }
}
