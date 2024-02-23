using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int FId { get; set; }
        public string? FName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
