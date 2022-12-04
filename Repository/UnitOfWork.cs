using BlogApi.Context;
using BlogApi.Interfaces;

namespace BlogApi.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IBlogRepository blogRepository;
    private IPostRepository postRepository;
    private readonly BlogDbContext _context;
    public UnitOfWork(BlogDbContext context)
    {
        _context = context;
    }

    public IBlogRepository BlogsRepository
        => blogRepository ??= new BlogRepository(_context);

    public IPostRepository PostsRepository
        => postRepository ??= new PostRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
