
namespace Movie.API.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int GenreId { get; set; }

    public int ReleaseYear { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
