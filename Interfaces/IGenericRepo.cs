using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BPD01_WebApi_Core.Interfaces
{
    public interface IGenericRepo<TEntity>
    {
         List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(object id);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(Object id);
    }
}