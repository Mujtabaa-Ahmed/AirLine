using System;
using System.Collections.Generic;

namespace Airline.Models
{
    public partial class User
    {
        public int UId { get; set; }
        public string? UName { get; set; }
        public string? UMail { get; set; }
        public string? UPass { get; set; }
        public int? RId { get; set; }

        public virtual Role? RIdNavigation { get; set; }
    }
}
