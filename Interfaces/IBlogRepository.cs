using BlogApi.Models;

namespace BlogApi.Interfaces;

public interface IBlogRepository : IGenericRepository<Blog>
{
    Task<IEnumerable<Blog>> GetBlogWithPostsAsync();
    Task<Blog> GetBlogWithPostsByIdAsync(int id);
}
