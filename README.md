# Manga Tracker API [STILL IN DEVELOPMENT]

## Overview

The **Manga Tracker API** is a RESTful API developed using C# .NET 8 and MySQL with an MVC architecture. This API aims to facilitate easy, organized, and intuitive tracking of manga reading progress. The API includes CRUD operations for four main entities: User, Manga, Genre, and Reading.

The concept behind this API is to solve a problem I had myself when trying to track my reading using a Google Sheet. While it works, it’s not practical. By creating this API, I can improve the tracking experience and practice my development skills, making it a win-win scenario. Here goes an idea of how was my sheet.

![image](https://github.com/caetanojpo/MangaTrackerAPI/assets/106156212/47356d9a-0281-41cb-98c4-d19ba65f9730)


## Table of Contents

- [Overview](#overview)
- [Entities](#entities)
  - [User](#user)
  - [Reading](#reading)
  - [Manga](#manga)
  - [Genre](#genre)
  - [MangaGenre](#mangagenre)
- [Functionality](#functionality)
  - [User](#user-1)
  - [Manga](#manga-1)
  - [Genre](#genre-1)
  - [Reading](#reading-1)
- [Future Plans](#future-plans)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgments](#acknowledgments)
  
## Entities

### User

Represents a user of the application.

```csharp
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
```

### Reading
Represents a reading record of a manga by a user.

```csharp
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
```
### Manga
Represents a manga title.

```csharp
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
```
### Genre
Represents a genre of manga.

```csharp
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
```

## Functionality

### User
- **Create User**: Add a new user to the system.
- **Read User**: Retrieve user details.
- **Update User**: Modify existing user information.
- **Delete User**: Remove a user from the system.

### Manga
- **Create Manga**: Add a new manga to the system.
- **Read Manga**: Retrieve manga details.
- **Update Manga**: Modify existing manga information.
- **Delete Manga**: Remove a manga from the system.

### Genre
- **Create Genre**: Add a new genre to the system.
- **Read Genre**: Retrieve genre details.
- **Update Genre**: Modify existing genre information.
- **Delete Genre**: Remove a genre from the system.

### Reading
- **Create Reading**: Add a new reading record.
- **Read Reading**: Retrieve reading details.
- **Update Reading**: Modify existing reading information.
- **Delete Reading**: Remove a reading record from the system.

## Features

### Authentication
- **User Authentication**: Implement JWT-based authentication for securing API endpoints.
- **Password Hashing**: Securely hash user passwords using a strong algorithm (e.g., bcrypt).

### Data Validation
- **Model Validation**: Ensure data integrity by validating model properties using data annotations.
- **Custom Validation**: Implement custom validation logic for complex business rules.

### Error Handling
- **Global Error Handling**: Implement a global exception handler to return consistent error responses.
- **Logging**: Integrate a logging framework (e.g., Serilog) to log errors and important events.

### Pagination & Filtering
- **Pagination**: Implement pagination for endpoints that return lists of resources.
- **Filtering**: Add support for filtering resources based on query parameters.

### Caching
- **Response Caching**: Implement caching for frequently accessed resources to improve performance.
- **Distributed Caching**: Use distributed caching (e.g., Redis) for scalability in a multi-server environment.

### Documentation
- **API Documentation**: Use Swagger to generate interactive API documentation.
- **Code Documentation**: Add XML comments to code for better maintainability and understanding.

### Security
- **Data Encryption**: Encrypt sensitive data both at rest and in transit.
- **Rate Limiting**: Implement rate limiting to protect the API from abuse and ensure fair usage.

### Performance Optimization
- **Database Indexing**: Optimize database queries using appropriate indexing strategies.
- **Load Testing**: Perform load testing to ensure the API can handle high traffic and scale accordingly.

### Monitoring & Analytics
- **Application Monitoring**: Use monitoring tools (e.g., Prometheus, Grafana) to track the health and performance of the API.
- **Usage Analytics**: Collect and analyze usage data to understand user behavior and improve the API.

## Future Plans
- **Front-end Development**: Develop a front-end using React and Next.js to provide an intuitive interface for users.
- **User Interface Prototyping**: Prototype the user interface for better usability and user experience.
- **API Enhancements**: Add additional features and improvements to the API, including but not limited to:
  - Advanced search and filtering capabilities for manga.
  - Recommendations based on user reading history.
  - Social features for sharing and discussing manga with other users.
- **Mobile App**: Develop a mobile application using React Native for cross-platform compatibility.
- **Notification System**: Implement a notification system to alert users about new manga releases or updates.

## Getting Started

To get started with the Manga Reading Tracker API, follow the instructions below:

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://www.mysql.com/downloads/)

### Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/yourusername/manga-reading-tracker.git
    ```
2. **Navigate to the project directory**:
    ```sh
    cd manga-reading-tracker
    ```
3. **Set up the database**: Update the connection string in `appsettings.json` to match your MySQL server configuration.

4. **Update the database**
    ```sh
    dotnet ef database update
    ```
    
5. **Run the application**:
    ```sh
    dotnet run
    ```

### Running Tests

1. **Navigate to the test project directory**:
    ```sh
    cd manga-reading-tracker.Tests
    ```
2. **Run the tests**:
    ```sh
    dotnet test
    ```

### API Documentation

1. **View the API documentation**:
    Open your browser and navigate to `http://localhost:5000/swagger` to view the interactive API documentation generated by Swagger.

## Author

[caetanojpo](https://github.com/caetanojpo)

---
