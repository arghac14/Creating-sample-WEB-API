using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models.Request;
using IMDBapp.Models;

namespace IMDBapp.Repositories
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> Get();
        public Genre GetById(int id);
        public void Post(Genre genre);
        public void Put(int id, Genre genre);
        public void Delete(int id);
        public IEnumerable<Genre> GetGenresByMovieId(int id);
    }
}
