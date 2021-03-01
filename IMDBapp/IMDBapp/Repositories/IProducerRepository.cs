using IMDBapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Repositories
{
    public interface IProducerRepository
    {
        public IEnumerable<Producer> Get();
        public Producer GetById(int id);
        public void Post(Producer producer);
        public void Put(int id, Producer producer);
        public void Delete(int id);
        public Producer GetProducerByMovieId(int movieId);
    }
}
