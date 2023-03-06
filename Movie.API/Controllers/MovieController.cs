using Microsoft.AspNetCore.Mvc;
using Movie.API.Interface;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetMovie")]

        public async Task<IActionResult> GetMovies(string genreName)
        {
            try
            {
                var movies = await _movieRepository.GetMovies(genreName);
                if (movies == null)
                {
                    return NotFound();
                }

                return movies.Count > 0 ? Ok(movies) : NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
