using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RId { get; set; }
        public string? RName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
