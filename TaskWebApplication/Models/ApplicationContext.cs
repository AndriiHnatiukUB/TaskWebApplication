using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskWebApplication.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("AppConnection")
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
    }
}