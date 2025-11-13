using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers;

public class ThreadsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}