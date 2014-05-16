using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SevenUp.DataAccess
{
   public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        int Create(TEntity instance);

        int Create(List<TEntity> instances);

        int Update(TEntity instance);

        int Delete(TEntity instance);

        int Delete(List<TEntity> instances);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);


        
    }
}
