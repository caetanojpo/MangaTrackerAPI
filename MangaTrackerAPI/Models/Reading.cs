namespace MangaTrackerAPI.Models;

public class Reading
{
   public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid MangaId { get; set; }
    public float CurrentChapter { get; set; }

    public Reading(Guid userId, Guid mangaId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        MangaId = mangaId;
        CurrentChapter = 0;
    }

    public void AddReading()
    {
        CurrentChapter++;
    }

    public void RemoveReading()
    {
        CurrentChapter--;
    }

    public float GetCurrentChapter()
    {
        return CurrentChapter;
    }
}
