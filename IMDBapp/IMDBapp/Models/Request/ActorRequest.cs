using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Models.Request
{
    public class ActorRequest
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
    }
}
