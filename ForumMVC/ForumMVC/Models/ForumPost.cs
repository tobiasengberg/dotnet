namespace ForumMVC.Models;

public class ForumPost
{
    public int Id { get; set; }
    public Poster Poster { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }

    public ForumPost()
    {
        
    }

    public ForumPost(Poster poster, string content)
    {
        this.Poster = poster;
        this.Content = content;
        this.PostedDate = DateTime.Now;
    }
}