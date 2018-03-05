using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskWebApplication.Infrastructure.Abstract;
using TaskWebApplication.Models;

namespace TaskWebApplication.Infrastructure.Implementation
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private ApplicationContext context;

        public OrganizationRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Organization> Organizations
        {
            get { return context.Organizations.Include(at => at.ActivityType); }
            //Include(at => at.ActivityType)
        }

        public Organization GetById(int? id)
        {
            Organization organization = context.Organizations.Include(at => at.ActivityType).SingleOrDefault(t => t.Id == id);
            return organization;
        }

        public void Save(Organization organization)
        {
            if (organization.Id == 0)
            {
                context.Organizations.Add(organization);
            }
            else
            {
                context.Entry(organization).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Organization dbEntry = context.Organizations.Find(id);
            if (dbEntry != null)
            {
                context.Organizations.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}