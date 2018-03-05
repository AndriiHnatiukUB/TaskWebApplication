using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskWebApplication.Infrastructure.Abstract;
using TaskWebApplication.Models;

namespace TaskWebApplication.Infrastructure.Implementation
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private ApplicationContext context;

        public ActivityTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<ActivityType> ActivityTypes
        {
            get { return context.ActivityTypes; }
        }

        public ActivityType GetById(int? id)
        {
            ActivityType activityType = context.ActivityTypes.Include(o => o.Organizations).SingleOrDefault(t => t.Id == id);
            return activityType;
        }

        public void Save(ActivityType activity)
        {
            if (activity.Id == 0)
            {
                context.ActivityTypes.Add(activity);
            }
            else
            {
                context.Entry(activity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            ActivityType dbEntry = context.ActivityTypes.Find(id);
            if (dbEntry != null)
            {
                context.ActivityTypes.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}