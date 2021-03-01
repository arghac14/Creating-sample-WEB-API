using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Controllers
{
    
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        [Route("/movie/{id}/review")]
        public IActionResult GetReviews(int id)
        {

            return Ok(id);

        }
    }
}
