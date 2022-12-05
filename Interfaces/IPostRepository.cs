using BlogApi.Models;

namespace BlogApi.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<IEnumerable<Post>> GetPostsWithBlogAsync();
    Task<Post> GetPostByIdWithBlogAsync(int id);
    Task<IEnumerable<Post>> GetPostsByBlogIdAsync(int id);
}
