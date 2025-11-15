namespace ForumMVC.Models;

public class ForumThread
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
    public Poster Poster { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }

    public ForumThread() { }

    public ForumThread(string title, Poster poster, string content)
    {
        this.Title = title;
        this.Poster = poster;
        ForumPost firstPost = new ForumPost(poster, content);
        ForumPosts.Add(firstPost);
        DateCreated = firstPost.PostedDate;
        LastUpdated = firstPost.PostedDate;
    }
}