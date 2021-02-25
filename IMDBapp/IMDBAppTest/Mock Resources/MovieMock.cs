using System;
using System.Collections.Generic;
using System.Linq;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using IMDBapp.Repositories;
using IMDBapp.Services;
using Moq;

namespace IMDBapp.Test
{
    class MovieMock
    {
        public static readonly Mock<IMovieService> MovieRepoMock = new Mock<IMovieService>();

        public static void MockGet()
        {
            MovieRepoMock.Setup(repo => repo.Get()).Returns(ListOfMovies());
        }

        public static void MockGetById()
        {
            MovieRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfMovies().SingleOrDefault(x => x.Id == id));
        }

        public static void MockAdd()
        {
            MovieRepoMock.Setup(repo => repo.Post(It.IsAny<MovieRequest>()));
        }

        public static void MockUpdate()
        {
            MovieRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<MovieRequest>()));
        }

        public static void MockDelete()
        {
            MovieRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

        private static IEnumerable<MovieResponse> ListOfMovies()
        {
            var movies = new List<MovieResponse>
            {
                new MovieResponse
                {
                  Id = 1,
                  Name = "Avengers",
                  YearOfRelease = 2012,
                  Plot = "--",
                  Poster = "link",
                  Producer = ProducerMock.GetProducerByMovieId(1),
                  Actor= ActorMock.GetActorByMovieId(1),
                  Genre=GenreMock.GetGenreByMovieId(1)
                }
            };
            return movies;
        }
    }
}
