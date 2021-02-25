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
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<ProducerResponse> Get()
        {
            var producers = _producerRepository.Get();
            List<ProducerResponse> producerList = new List<ProducerResponse>();

            producers.ToList().ForEach(p =>
            {               
                producerList.Add(new ProducerResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = p.Gender,
                    Bio = p.Bio,
                    DOB = p.DOB
                });
            });

            return producerList;
        }

        public ProducerResponse Get(int id)
        {
            var p = _producerRepository.GetById(id);
            var producer = new ProducerResponse
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                Bio = p.Bio,
                DOB = p.DOB
            };
            return producer;

        }
        public void Post(ProducerRequest producer)
        {            
            _producerRepository.Post(new Producer
            {
                Name = producer.Name,
                Gender = producer.Gender,
                Bio = producer.Bio,
                DOB = producer.DOB
            });
        }

        public void Put(int id, ProducerRequest producer)
        {
            _producerRepository.Put(id, new Producer
            {
                Name = producer.Name,
                Gender = producer.Gender,
                Bio = producer.Bio,
                DOB = producer.DOB
            });
        }
        public void Delete(int id)
        {
            _producerRepository.Delete(id);
        }
    }
}
