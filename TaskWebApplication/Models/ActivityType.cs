using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}