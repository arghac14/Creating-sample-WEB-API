using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;

namespace IMDBapp.Services
{
    public interface IGenreService
    {
        public IEnumerable<GenreResponse> Get();
        public GenreResponse Get(int id);
        public void Post(GenreRequest genreDTO);
        public void Put(int id, GenreRequest genreDTO);
        public void Delete(int id);
    }
}
