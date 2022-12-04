using BlogApi.Context;
using BlogApi.Interfaces;
using BlogApi.Models;

namespace BlogApi.Repository;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(BlogDbContext context)
        : base(context) { }
}
