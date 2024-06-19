using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaTrackerAPI.Models
{
    [Table("Mangas")]
    public class Manga
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(80)]
        public string Author { get; set; }

        [Required]
        public float TotalChapters { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();

        public ICollection<Reading> Readings { get; set; } = new List<Reading>();

        public string CoverUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Manga(string title, string author, float totalChapters, string description, string coverUrl)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            TotalChapters = totalChapters;
            Description = description;
            CoverUrl = coverUrl;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
