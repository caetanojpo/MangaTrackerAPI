using MangaTrackerAPI.Enums;
using MangaTrackerAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaTracker.Models;

[Table("Users")]
public class User
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    [StringLength(80)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string HashedPassword { get; set; }
    [Required]
    [StringLength(30)]
    public string Email { get; set; }
    [Required]
    [StringLength(15)]
    public string Cellphone { get; set; }
    [Required]
    public UserPermission Permission { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();

    public User(string name, string hashedPassword, string email, string cellphone)
    {
        UserId = Guid.NewGuid();
        Name = name;
        HashedPassword = hashedPassword;
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
