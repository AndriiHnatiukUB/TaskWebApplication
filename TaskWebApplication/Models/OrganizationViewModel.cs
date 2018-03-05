using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Models
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Activity { get; set; }
        public int ActivityTypeId { get; set; }
    }
}