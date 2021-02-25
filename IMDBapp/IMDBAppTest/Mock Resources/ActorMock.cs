using System;
using System.Collections.Generic;
using System.Linq;
using IMDBapp.Models;
using IMDBapp.Repositories;
using Moq;

namespace IMDBapp.Test
{
    class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        public static void MockGet()
        {
            ActorRepoMock.Setup(repo => repo.Get()).Returns(ListOfActors());
        }

        public static void MockGetById()
        {
            ActorRepoMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int id) => ListOfActors().SingleOrDefault(x => x.Id == id));
        }

        public static void MockAdd()
        {
            ActorRepoMock.Setup(repo => repo.Post(It.IsAny<Actor>()));
        }

        public static void MockUpdate()
        {
            ActorRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Actor>()));
        }

        public static void MockDelete()
        {
            ActorRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }


        private static IEnumerable<Actor> ListOfActors()
        {
            var actors = new List<Actor>
            {
                new Actor
                {
                  Id=1,
                  Name="RDJ",
                  Gender="M",
                  Bio="American Actor",
                  DOB=new DateTime(2000,01,01)
                }
            };
            return actors;
        }

        public static Dictionary<int, List<int>> MovieActorsMapping()
        {
            var movieActorsMapping = new Dictionary<int, List<int>>
                {
                    {1, new List<int> {1}}
                };
            return movieActorsMapping;
        }

        public static List<Actor> GetActorByMovieId(int movieId)
        {
            List<Actor> actors = new List<Actor>();
            var movieActorsMapping = MovieActorsMapping();

            movieActorsMapping[movieId].ForEach(id =>
            {
                actors.Add(ListOfActors().Single(a => a.Id == id));
            });

            return actors;
        }
    }
}
