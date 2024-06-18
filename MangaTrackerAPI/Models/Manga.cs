namespace MangaTrackerAPI.Models;

public class Manga
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public float TotalChapters { get; set; }
    public string Description { get; set; }
    public List<Genre> Genres { get; set; }
    public string CoverUrl { get; set; }

    public Manga
        (string title,
        string author,
        float totalChapters,
        string description,
        string coverUrl)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        TotalChapters = totalChapters;
        Description = description;
        Genres = new List<Genre>();
        CoverUrl = coverUrl;
    }
}
