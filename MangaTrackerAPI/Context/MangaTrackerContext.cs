using MangaTracker.Models;
using MangaTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaTrackerAPI.Context;

public class MangaTrackerContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Manga> Mangas {  get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MangaGenre> MangaGenres { get; set; }
    public DbSet<Reading> Readings { get; set; }

    public MangaTrackerContext(DbContextOptions<MangaTrackerContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MangaGenre>()
            .HasKey(mg => new { mg.MangaId, mg.GenreId });

        modelBuilder.Entity<MangaGenre>()
            .HasOne(mg => mg.Manga)
            .WithMany(m => m.MangaGenres)
            .HasForeignKey(mg => mg.MangaId);

        modelBuilder.Entity<MangaGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MangaGenres)
            .HasForeignKey(mg => mg.GenreId);

        modelBuilder.Entity<Reading>()
               .HasKey(r => r.Id);

        modelBuilder.Entity<Reading>()
            .HasOne(r => r.User)
            .WithMany(u => u.Readings)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Reading>()
            .HasOne(r => r.Manga)
            .WithMany(m => m.Readings)
            .HasForeignKey(r => r.MangaId);
    }
}
