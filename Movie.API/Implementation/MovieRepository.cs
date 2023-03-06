using Microsoft.EntityFrameworkCore;
using Movie.API.Interface;
using Movie.API.Models;
using Movie.API.ViewModel;

namespace Movie.API.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        ImdbContext _context;
        public MovieRepository(ImdbContext imdbContext) { _context = imdbContext; }

        public async Task<List<MovieViewModel>> GetMovies(string GenreName)
        {

            if (_context != null)
            {
                return await (from m in _context.Movies
                              from g in _context.Genres
                              where (m.GenreId == g.Id && g.GenreName == GenreName)
                              select new MovieViewModel
                              {
                                  Id = m.Id,
                                  Title = m.Title,
                                  ReleaseYear = m.ReleaseYear,
                                  Genre = g.GenreName

                              }).ToListAsync();
            }
            return null;

        }

    }
}
