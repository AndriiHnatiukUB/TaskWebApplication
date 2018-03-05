using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWebApplication.Infrastructure.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> Get { get; }
        TEntity GetById(int id);
        void Remove(TEntity entity);
    }
}
