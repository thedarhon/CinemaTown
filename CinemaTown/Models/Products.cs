using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTown.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public override string ToString()
        {
            return ProductName + " " + Price + " ";

        }
    }
}