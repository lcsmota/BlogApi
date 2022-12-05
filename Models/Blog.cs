using System.Text.Json.Serialization;

namespace BlogApi.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Post> Posts { get; set; } = new();
}
