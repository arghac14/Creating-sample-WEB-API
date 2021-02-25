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
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IEnumerable<ActorResponse> Get()
        {
            var actors = _actorRepository.Get();
            List<ActorResponse> actorList = new List<ActorResponse>();

            actors.ToList().ForEach(a =>
            {
                actorList.Add(new ActorResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                    Gender = a.Gender,
                    Bio = a.Bio,
                    DOB = a.DOB
                });
            });

            return actorList;
        }

        public ActorResponse Get(int id)
        {
            var a = _actorRepository.GetById(id);
            ActorResponse actor = new ActorResponse()
            {
                Id = a.Id,
                Name = a.Name,
                Gender = a.Gender,
                Bio = a.Bio,
                DOB = a.DOB
            };
            return actor;

        }
        public void Post(ActorRequest actor) 
        {
            _actorRepository.Post(new Actor()
            {
                Name = actor.Name,
                Gender = actor.Gender,
                Bio = actor.Bio,
                DOB = actor.DOB
            }); 
        }

        public void Put(int id, ActorRequest actor)
        {
            _actorRepository.Put(id, new Actor()
            {
                Name = actor.Name,
                Gender = actor.Gender,
                Bio = actor.Bio,
                DOB = actor.DOB
            });  
        }
        public void Delete(int id)
        {
            _actorRepository.Delete(id);
        }
    }
}
