using ForumMVC.Data;
using ForumMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers;

public class ThreadsController : Controller
{
    private readonly ForumDB _context;

    public ThreadsController(ForumDB context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        List<ForumThread> threads = _context.ForumThreads.ToList();
        return View(threads);
    }
    
    public IActionResult Create(string poster, string title, string content)
    {
        Poster newPoster = new Poster {NickName = poster};
        List<ForumPost> forumPosts = new List<ForumPost>();
        ForumPost forumPost = new ForumPost {Poster = newPoster, Content = content, PostedDate = DateTime.Now};
        forumPosts.Add(forumPost);
        ForumThread forumThread = new ForumThread {Title = title, ForumPosts = forumPosts, Poster = newPoster};
        _context.ForumThreads.Add(forumThread);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}