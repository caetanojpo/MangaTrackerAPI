using MangaTrackerAPI.Enums;

namespace MangaTracker.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }
    public string Cellphone { get; set; }
    public UserPermission Permission { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User(string name, string password, string email, string cellphone)
    {
        UserId = Guid.NewGuid();
        Name = name;
        HashedPassword = HashPassword(password);
        Email = email;
        Cellphone = cellphone;
        Permission = UserPermission.User;
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    private string HashPassword(string password)
    {
        return ""; //TODO IMPLEMENT PASSWORD HASHER
    }

    private string Login(string email, string password)
    {
        return "";
    }
}
