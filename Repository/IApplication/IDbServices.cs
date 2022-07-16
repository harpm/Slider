using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Slider5.Repository.IApplication
{
    public interface IDbServices<TEntity>
    {
        public void Add(TEntity entity);
        public TEntity Get(int id);
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, Boolean>> predicate);
        public void Delete(int id);
    }
}
