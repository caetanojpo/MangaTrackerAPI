using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaTrackerAPI.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Genre(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
