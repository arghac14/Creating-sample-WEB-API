using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Repositories;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using IMDBapp.Models;

namespace IMDBapp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IProducerRepository producerRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
            _genreRepository = genreRepository;
        }

        public IEnumerable<MovieResponse> Get()
        {
            var movies = _movieRepository.Get();
            var movieList = new List<MovieResponse>();

            movies.ToList().ForEach(m =>
            {
                var actor = _actorRepository.GetActorsByMovieId(m.Id);
                var genre = _genreRepository.GetGenresByMovieId(m.Id);
                var producer = _producerRepository.GetById(m.ProducerId);

                movieList.Add(new MovieResponse
                {
                    Id = m.Id,
                    Name = m.Name,
                    YearOfRelease = m.YearOfRelease,
                    Plot = m.Plot,
                    Poster = m.Poster,
                    Actor = actor.ToList(),
                    Genre = genre.ToList(),
                    Producer = producer
                });
            });
            return movieList;
        }

        public MovieResponse Get(int Id)
        {
            var m = _movieRepository.GetById(Id);
            var movie = new MovieResponse
            {
                Id = m.Id,
                Name = m.Name,
                YearOfRelease = m.YearOfRelease,
                Plot = m.Plot,
                Poster = m.Poster,
                Actor = _actorRepository.GetActorsByMovieId(m.Id).ToList(),
                Genre = _genreRepository.GetGenresByMovieId(m.Id).ToList(),
                Producer = _producerRepository.GetById(m.ProducerId)
            };
            return movie;
        }

        public void Post(MovieRequest movie)
        {
            var actorIdList = movie.Actor;
            var genreIdList = movie.Genre;

            _movieRepository.Post(new Movie
            {
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                Poster = movie.Poster,
                ProducerId = movie.ProducerId
            }, actorIdList, genreIdList);
        }

        public void Put(int id, MovieRequest movie)
        {            
            var actorIdList = movie.Actor;
            var genreIdList = movie.Genre;

            _movieRepository.Put(id, new Movie
            {
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                Poster = movie.Poster,
                ProducerId = movie.ProducerId
            }, actorIdList, genreIdList);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

    }
}
