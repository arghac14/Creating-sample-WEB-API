using System;
using System.Collections.Generic;
using System.Linq;
using IMDBapp.Models;
using IMDBapp.Repositories;
using Moq;

namespace IMDBapp.Test
{
    class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        public static void MockGet()
        {
            GenreRepoMock.Setup(repo => repo.Get()).Returns(ListOfGenres());
        }

        public static void MockGetById()
        {
            GenreRepoMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int id) => ListOfGenres().SingleOrDefault(x => x.Id == id));
        }

        public static void MockAdd()
        {
            GenreRepoMock.Setup(repo => repo.Post(It.IsAny<Genre>()));
        }

        public static void MockUpdate()
        {
            GenreRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Genre>()));
        }

        public static void MockDelete()
        {
            GenreRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }


        private static IEnumerable<Genre> ListOfGenres()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Thriller"
                }
            };
            return genres;
        }

        public static Dictionary<int, List<int>> MovieGenresMapping()
        {
            var movieGenresMapping = new Dictionary<int, List<int>>
            {
                {1, new List<int>{1} }
            };
            return movieGenresMapping;
        }    

        public static List<Genre> GetGenreByMovieId(int movieId)
        {
            List<Genre> genres = new List<Genre>();
            var movieGenresMapping = MovieGenresMapping();

            movieGenresMapping[movieId].ForEach(id =>
            {
                genres.Add(ListOfGenres().Single(g => g.Id == id));
            });

            return genres;
        }

    }
}
