namespace ForumMVC.Models;

public class ForumThread
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ForumPost> ForumPosts { get; set; }
    public Poster Poster { get; set; }
}