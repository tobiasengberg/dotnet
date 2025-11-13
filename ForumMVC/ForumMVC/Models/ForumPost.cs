namespace ForumMVC.Models;

public class ForumPost
{
    public int Id { get; set; }
    public Poster Poster { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
}