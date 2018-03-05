using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWebApplication.Models;

namespace TaskWebApplication.Infrastructure.Abstract
{
    public interface IActivityTypeRepository
    {
        void Save(ActivityType activity);
        IEnumerable<ActivityType> ActivityTypes { get; }
        ActivityType GetById(int? id);
        void Remove(int id);
    }
}
