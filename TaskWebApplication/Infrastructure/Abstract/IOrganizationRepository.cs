using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWebApplication.Models;

namespace TaskWebApplication.Infrastructure.Abstract
{
    public interface IOrganizationRepository
    {
        void Save(Organization organization);
        IEnumerable<Organization> Organizations { get; }
        Organization GetById(int? id);
        void Remove(int id);
    }
}
