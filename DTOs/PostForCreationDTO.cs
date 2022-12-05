namespace BlogApi.DTOs;

public class PostForCreationDTO
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }

    public int BlogId { get; set; }
}
