using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Class
    {
        public Class()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CId { get; set; }
        public string? CName { get; set; }
        public int? CPrice { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
