using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTown.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}