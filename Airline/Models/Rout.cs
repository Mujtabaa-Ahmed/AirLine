using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Rout
    {
        public Rout()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int RoutId { get; set; }
        public string? RoutName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
