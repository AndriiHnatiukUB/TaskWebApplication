using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}