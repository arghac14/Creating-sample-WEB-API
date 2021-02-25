using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models.Request;
using IMDBapp.Models;

namespace IMDBapp.Repositories
{
    public interface IActorRepository
    {
        public IEnumerable<Actor> Get();
        public Actor GetById(int id);
        public void Post(Actor actor);
        public void Put(int id, Actor actor);
        public void Delete(int id);
        public IEnumerable<Actor> GetActorsByMovieId(int id);
    }
}
