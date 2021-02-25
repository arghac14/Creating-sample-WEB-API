using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Services;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBapp.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IActionResult Get()
        {
            var producers = _producerService.Get();
            return Ok(producers);
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producers = _producerService.Get(id);

            if (producers == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(producers);
            }
        }

        // POST api/<ProducerController>
        [HttpPost]
        public IActionResult Post([FromBody] ProducerRequest producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _producerService.Post(producer);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProducerRequest producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _producerService.Put(id, producer);
            return Ok("Record updated!");
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            return Ok("Record deleted!");
        }
    }
}
