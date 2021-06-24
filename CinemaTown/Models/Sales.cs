using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTown.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public int TicketId { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Tickets Tickets { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Products Products { get; set; }
    }
}