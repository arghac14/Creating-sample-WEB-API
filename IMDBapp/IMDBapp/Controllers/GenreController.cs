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
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreService.Get();
            return Ok(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genres = _genreService.Get(id);

            if (genres == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(genres);
            }
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreRequest genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _genreService.Post(genre);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreRequest genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _genreService.Put(id, genre);
            return Ok("Record updated!");
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return Ok("Record deleted!");
        }
    }
}
