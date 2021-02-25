using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using IMDBapp.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBapp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _movieService.Get();
            if (movies == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(movies);
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movies = _movieService.Get(id);
            if (movies == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(movies);
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieRequest movie)
        {
            _movieService.Post(movie);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovieRequest movie)
        {
            _movieService.Put(id, movie); 
            return Ok("Record updated!");
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok("Record deleted!");
        }
    }
}
