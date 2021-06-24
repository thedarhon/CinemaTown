using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTown.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

         public override string ToString()
        {
            return Type + " " + Price + " ";
        }

    }
}