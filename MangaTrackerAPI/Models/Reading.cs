using MangaTracker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaTrackerAPI.Models;

[Table("Readings")]
public class Reading
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; }
    [Required]
    public Guid MangaId { get; set; }
    [Required]
    public Manga Manga { get; set; }
    [Required]
    public float CurrentChapter { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Reading()
    {
        Id = Guid.NewGuid();
        CurrentChapter = 0;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void AddReading()
    {
        CurrentChapter++;
        UpdatedAt = DateTime.Now;
    }

    public void RemoveReading()
    {
        CurrentChapter--;
        UpdatedAt = DateTime.Now;
    }

    public float GetCurrentChapter()
    {
        return CurrentChapter;
    }
}
