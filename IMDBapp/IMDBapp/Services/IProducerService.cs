using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Services
{
    public interface IProducerService
    {
        public IEnumerable<ProducerResponse> Get();
        public ProducerResponse Get(int id);
        public void Post(ProducerRequest actor);
        public void Put(int id, ProducerRequest actor);
        public void Delete(int id);
    }
}
