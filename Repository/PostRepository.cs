using BlogApi.Context;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly BlogDbContext _context;
    public PostRepository(BlogDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPostsByBlogIdAsync(int id)
    {
        return await _context.Posts
                             .Include(e => e.Blog)
                             .AsNoTracking()
                             .Where(prop => prop.BlogId == id)
                             .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetPostsWithBlogAsync()
    {
        return await _context.Posts
                             .Include(e => e.Blog)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task<Post> GetPostByIdWithBlogAsync(int id)
    {
        return await _context.Posts
                             .Include(e => e.Blog)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(prop => prop.PostId == id);
    }
}
