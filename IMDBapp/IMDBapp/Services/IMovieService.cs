using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;

namespace IMDBapp.Services
{
    public interface IMovieService
    {
        public IEnumerable<MovieResponse> Get();
        public MovieResponse Get(int Id);
        public void Post(MovieRequest movie);
        public void Put(int id, MovieRequest movie);
        public void Delete(int id);
    }
}
