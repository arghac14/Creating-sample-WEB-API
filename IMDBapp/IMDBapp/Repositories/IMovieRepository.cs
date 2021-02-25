using IMDBapp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;

namespace IMDBapp.Repositories
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> Get();
        public Movie GetById(int id);
        public void Post(Movie movie, List<int> actors, List<int> genre);
        public void Put(int id, Movie movie, List<int> actors, List<int> genre);
        public void Delete(int id);
    }
}
