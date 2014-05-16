using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SevenUp.DataAccess
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext Context { get;set;}
        private DbSet<TEntity> dbSet
        { 
            get
            {
                return this.Context.Set<TEntity>();
            }
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this.Context.Database.Log = (log) => Debug.WriteLine(log);


        }
        public virtual int Create(TEntity instance)
        {
            this.dbSet.Add(instance);
            return this.Context.SaveChanges();
        }

        public virtual int Create(List<TEntity> instances)
        {
            this.dbSet.AddRange(instances);
            return this.Context.SaveChanges();
        }

        public virtual int Update(TEntity instance)
        {
            this.Context.Entry(instance).State = EntityState.Modified;
            return this.Context.SaveChanges();
        }

        public virtual int Update(List<TEntity> instances)
        {
            instances.ForEach((instance) =>{this.Context.Entry(instance).State = EntityState.Modified;});
            return this.Context.SaveChanges();
        }

        public virtual int Delete(TEntity instance)
        {
            this.dbSet.Remove(instance);
            return this.Context.SaveChanges();
        }

        public virtual int Delete(List<TEntity> instances)
        {
            this.dbSet.RemoveRange(instances);
            return this.Context.SaveChanges();
            
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            this.Delete(predicate);
            return this.Context.SaveChanges();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.Where<TEntity>(predicate);   
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }
    }
}
