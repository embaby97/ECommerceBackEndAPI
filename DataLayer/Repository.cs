using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository<TEntity> where TEntity : class
    {
        // public DbSet<TEntity> dbSet;
        private readonly ApplicationContext dbContext;
        public Repository(ApplicationContext context)
        {
            dbContext = context;
            // dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> AsQuerable()
        {
            return dbContext.Set<TEntity>();
        }


        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }



        public virtual void Insert(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entity)
        {
            dbContext.Set<TEntity>().RemoveRange(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            dbContext.Set<TEntity>().AddRange(entity);
        }
    }
}