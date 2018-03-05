using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskWebApplication.Infrastructure.Abstract;
using TaskWebApplication.Models;

namespace TaskWebApplication.Infrastructure.Implementation
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class 
    {
        private ApplicationContext context;
        private DbSet<TEntity> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get
        {
            get { return entities.AsNoTracking(); }
            //Include(at => at.ActivityType)
        }

        public TEntity GetById(int id)
        {
            return entities.Find(id);
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            entities.Remove(entity);
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}