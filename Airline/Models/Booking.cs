using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Booking
    {
        public int BId { get; set; }
        public int? BQuan { get; set; }
        public int? BAmount { get; set; }
        public int? CId { get; set; }
        public int? SId { get; set; }

        public virtual Class? CIdNavigation { get; set; }
        public virtual Schedule? SIdNavigation { get; set; }
    }
}
