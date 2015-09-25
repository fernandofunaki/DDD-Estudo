using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IQueryRepository<TEntity, TId>
        where TId : struct
        where TEntity : Entity<TId>
    {
        IQueryable<TEntity> Query(Expression<System.Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
