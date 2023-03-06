using Movie.API.Models;

namespace Movie.API.ViewModel
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Genre { get; set; }
    }
}
