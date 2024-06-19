using MangaTracker.Models;
using MangaTrackerAPI.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTables : Migration
    {
        string userId = Guid.NewGuid().ToString();
        string mangaId = Guid.NewGuid().ToString();
        string genreId1 = Guid.NewGuid().ToString();
        string genreId2 = Guid.NewGuid().ToString();
        string readingId = Guid.NewGuid().ToString();
        string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($"INSERT INTO Users (UserId, Name, HashedPassword, Email, Cellphone, Permission, IsActive, CreatedAt, UpdatedAt) " +
                  $"VALUES('{userId}', 'Test User', 'test123', 'test@test.com', '1234567890', 1, true, '{dateTimeNow}', '{dateTimeNow}');");

            migrationBuilder.Sql($"INSERT INTO Mangas (Id, Title, Author, TotalChapters, Description, CoverUrl, CreatedAt, UpdatedAt) " +
                                 $"VALUES ('{mangaId}', 'Naruto', 'Masashi Kishimoto', 700, 'A story about ninjas', 'https://http2.mlstatic.com/D_NQ_NP_684777-MLU50423879264_062022-O.webp', '{dateTimeNow}', '{dateTimeNow}');");

            migrationBuilder.Sql($"INSERT INTO Genres (Id, Name, CreatedAt, UpdatedAt) " +
                                 $"VALUES ('{genreId1}', 'Action', '{dateTimeNow}', '{dateTimeNow}');");

            migrationBuilder.Sql($"INSERT INTO Genres (Id, Name, CreatedAt, UpdatedAt) " +
                                 $"VALUES ('{genreId2}', 'Adventure', '{dateTimeNow}', '{dateTimeNow}');");


            migrationBuilder.Sql($"INSERT INTO MangaGenres (MangaId, GenreId) VALUES ('{mangaId}', '{genreId1}');");
            migrationBuilder.Sql($"INSERT INTO MangaGenres (MangaId, GenreId) VALUES ('{mangaId}', '{genreId2}');");

            migrationBuilder.Sql($"INSERT INTO Readings (Id, UserId, MangaId, CurrentChapter, CreatedAt, UpdatedAt) " +
                                 $"VALUES ('{readingId}', '{userId}', '{mangaId}', 5, '{dateTimeNow}', '{dateTimeNow}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM Readings WHERE Id = '{readingId}';");
            migrationBuilder.Sql($"DELETE FROM MangaGenres WHERE MangaId = '{mangaId}' AND GenreId = '{genreId1}';");
            migrationBuilder.Sql($"DELETE FROM MangaGenres WHERE MangaId = '{mangaId}' AND GenreId = '{genreId2}';");
            migrationBuilder.Sql($"DELETE FROM Genres WHERE Id = '{genreId1}';");
            migrationBuilder.Sql($"DELETE FROM Genres WHERE Id = '{genreId2}';");
            migrationBuilder.Sql($"DELETE FROM Mangas WHERE Id = '{mangaId}';");
            migrationBuilder.Sql($"DELETE FROM Users WHERE UserId = '{userId}';");
        }
    }
}
