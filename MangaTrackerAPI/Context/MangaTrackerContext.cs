using MangaTracker.Models;
using MangaTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaTrackerAPI.Context;

public class MangaTrackerContext : DbContext
{
    public MangaTrackerContext(DbContextOptions<MangaTrackerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Manga> Mangas {  get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Reading> Readings { get; set; }
}
