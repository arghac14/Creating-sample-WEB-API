using System;
using System.Collections.Generic;
using System.Linq;
using IMDBapp.Models;
using IMDBapp.Repositories;
using Moq;

namespace IMDBapp.Test
{
    class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        public static void MockGet()
        {
            ProducerRepoMock.Setup(repo => repo.Get()).Returns(ListOfProducers());
        }

        public static void MockGetById()
        {
            ProducerRepoMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int id) => ListOfProducers().SingleOrDefault(x => x.Id == id));
        }


        public static void MockAdd()
        {
            ProducerRepoMock.Setup(repo => repo.Post(It.IsAny<Producer>()));
        }

        public static void MockUpdate()
        {
            ProducerRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Producer>()));
        }

        public static void MockDelete()
        {
            ProducerRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

        private static IEnumerable<Producer> ListOfProducers()
        {
            var producers = new List<Producer>
            {
                new Producer
                {
                  Id=1,
                  Name="Kevin Feigi",
                  Gender="M",
                  Bio="American Producer",
                  DOB=new DateTime(2000,01,01)

                }
            };
            return producers;
        }

        public static Dictionary<int, int> MovieProducerMapping() => new Dictionary<int, int>
        {
            {1, 1}
        };

        public static Producer GetProducerByMovieId(int movieId)
        {
            var listOfProducers = ListOfProducers();
            var movieProducerMapping = MovieProducerMapping();

            var producer = listOfProducers.Where(p=>p.Id == movieProducerMapping[movieId]).First();
         
            return producer;
        }
    }
}
