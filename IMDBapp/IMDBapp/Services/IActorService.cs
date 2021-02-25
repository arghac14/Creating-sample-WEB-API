using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;

namespace IMDBapp.Services
{
    public interface IActorService
    {
        public IEnumerable<ActorResponse> Get();
        public ActorResponse Get(int id);
        public void Post(ActorRequest actor);
        public void Put(int id, ActorRequest actor);
        public void Delete(int id);
    }
}
