using ForumMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumMVC.Data;

public class ForumDB : DbContext
{
    public ForumDB(DbContextOptions<ForumDB> options) : base(options)
    {
        
    }

    public DbSet<ForumThread> ForumThreads { get; set; }
}