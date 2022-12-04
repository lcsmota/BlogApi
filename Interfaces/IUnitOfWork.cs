namespace BlogApi.Interfaces;

public interface IUnitOfWork
{
    public IBlogRepository BlogsRepository { get; }
    public IPostRepository PostsRepository { get; }
    Task CommitAsync();
}
