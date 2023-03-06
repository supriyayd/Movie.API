using Movie.API.Controllers;
using Movie.API.Interface;
using Movie.API.ViewModel;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Movie.API.Tests.Unit
{
    public class MovieApiControllerTest
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        public MovieApiControllerTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
        }

        [Fact]
        public async Task GetMovieReturns200()
        {
            //Setup
            _mockMovieRepository.Setup(x => x.GetMovies(It.IsAny<string>())).ReturnsAsync(GetMovieList());

            //Act
            var controller = new MovieController(_mockMovieRepository.Object);
            var result = await controller.GetMovies("sci-fi");
            var movieList = ((ObjectResult)result).Value;

            //Assert
            result.Equals(HttpStatusCode.OK);
            Assert.NotNull(movieList);

        }

        [Fact]
        public async Task GetMovieReturns204()
        {
            //Setup
            _mockMovieRepository.Setup(x => x.GetMovies(It.IsAny<string>())).ReturnsAsync(new List<MovieViewModel>());

            //Act
            var controller = new MovieController(_mockMovieRepository.Object);
            var result = await controller.GetMovies("sci-fi");

            //Assert
            result.Equals(HttpStatusCode.NoContent);

        }

        [Fact]
        public async Task GetMovieReturns404()
        {
            //Setup
            _mockMovieRepository.Setup(x => x.GetMovies(It.IsAny<string>())).ReturnsAsync((List<MovieViewModel>)null);

            //Act
            var controller = new MovieController(_mockMovieRepository.Object);
            var result = await controller.GetMovies("sci-fi");

            //Assert
            result.Equals(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task GetMovieReturns400()
        {

            //Act
            var controller = new MovieController(_mockMovieRepository.Object);
            var result = await controller.GetMovies(null);

            //Assert
            result.Equals(HttpStatusCode.BadRequest);

        }

        public List<MovieViewModel> GetMovieList()
        {
            return new List<MovieViewModel>
            {
                new MovieViewModel{Genre="sci-fi",Id=1,ReleaseYear=2022, Title="Test Movie"}
            };
        }
    }
}