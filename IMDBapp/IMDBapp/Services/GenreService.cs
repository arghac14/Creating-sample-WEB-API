using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Repositories;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;

namespace IMDBapp.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<GenreResponse> Get()
        {
            var genres = _genreRepository.Get();
            List<GenreResponse> genreList = new List<GenreResponse>();

            genres.ToList().ForEach(g =>
            {              
                genreList.Add(new GenreResponse
                {
                    Id = g.Id,
                    Name = g.Name
                });
            });

            return genreList;
        }

        public GenreResponse Get(int id)
        {
            var g = _genreRepository.GetById(id);
            var genre = new GenreResponse
            {
                Id = g.Id,
                Name = g.Name
            };
            return genre;

        }
        public void Post(GenreRequest genre)
        {
            _genreRepository.Post(new Genre
            {
                Name = genre.Name
            });
        }

        public void Put(int id, GenreRequest genre)
        {
            _genreRepository.Put(id, new Genre
            {
                Name = genre.Name
            });
        }
        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }
    }
}
