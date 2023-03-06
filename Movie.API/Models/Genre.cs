using System;
using System.Collections.Generic;

namespace Movie.API.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
