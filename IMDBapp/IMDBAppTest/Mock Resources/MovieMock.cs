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
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        public static void MockGet()
        {
            MovieRepoMock.Setup(repo => repo.Get()).Returns(ListOfMovies());
        }

        public static void MockGetById()
        {
            MovieRepoMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int id) => ListOfMovies().SingleOrDefault(x => x.Id == id));
        }

        public static void MockAdd()
        {
            MovieRepoMock.Setup(repo => repo.Post(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()));
        }

        public static void MockUpdate()
        {
            MovieRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()));
        }

        public static void MockDelete()
        {
            MovieRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

        private static IEnumerable<Movie> ListOfMovies()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                  Id = 1,
                  Name = "Avengers",
                  YearOfRelease = 2012,
                  Plot = "--",
                  Poster = "link",
                  ProducerId = 1
                }
            };
            return movies;
        }
    }
}
