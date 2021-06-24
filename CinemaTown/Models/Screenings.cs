using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTown.Models
{
    public class Screenings
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual Halls Halls { get; set; }
        public virtual Movies Movies { get; set; }
    }
}