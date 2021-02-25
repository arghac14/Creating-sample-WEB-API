using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Models.Request
{
    public class MovieRequest
    {
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public int ProducerId { get; set; }
        public List<int> Actor { get; set; }
        public List<int> Genre { get; set; }
    }
}
