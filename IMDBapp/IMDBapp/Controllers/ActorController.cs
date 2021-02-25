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
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get()
        {
            var actors = _actorService.Get();
            return Ok(actors);
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actors = _actorService.Get(id);
            
            if (actors == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(actors);
            }
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _actorService.Post(actor);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _actorService.Put(id, actor);
            return Ok("Record updated!");
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _actorService.Delete(id);
            return Ok("Record deleted!");
        }
    }
}
