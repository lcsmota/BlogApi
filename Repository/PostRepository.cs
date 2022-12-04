using BlogApi.Context;
using BlogApi.Interfaces;
using BlogApi.Models;

namespace BlogApi.Repository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(BlogDbContext context)
        : base(context) { }
}
