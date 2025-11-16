using ForumMVC.Data;
using ForumMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        List<ForumThread> threads = _context.ForumThreads
            .Include(p => p.Poster)
            .ToList();
        return View(threads);
    }
    
    public IActionResult Create(string poster, string title, string content)
    {
        Poster newPoster = new Poster {NickName = poster};
        ForumThread forumThread = new ForumThread(title, newPoster, content);
        _context.ForumThreads.Add(forumThread);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Thread(int id)
    {
        ForumThread thread = _context.ForumThreads
            .Include(f => f.ForumPosts)
            .ThenInclude(p => p.Poster)
            .FirstOrDefault(t => t.Id == id);
        return View(thread);
    }
    
    public IActionResult Reply(int id, string content, string poster)
    {
        ForumThread thread = _context.ForumThreads
            .Include(f => f.ForumPosts)
            .FirstOrDefault(t => t.Id == id);
        thread.ForumPosts.Add(new ForumPost(new Poster {NickName = poster}, content));
        _context.SaveChanges();
        return RedirectToAction("Thread", new {Id = id});
    }
}