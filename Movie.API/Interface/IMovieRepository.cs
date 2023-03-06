using Movie.API.ViewModel;

namespace Movie.API.Interface
{
    public interface IMovieRepository
    {
        Task<List<MovieViewModel>?> GetMovies(string GenreName);
    }
}
