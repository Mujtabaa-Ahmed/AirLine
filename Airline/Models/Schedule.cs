using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SId { get; set; }
        public int? FId { get; set; }
        public int? RoutId { get; set; }
        public DateTime? SDeparture { get; set; }
        public DateTime? SArival { get; set; }

        public virtual Flight? FIdNavigation { get; set; }
        public virtual Rout? Rout { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
