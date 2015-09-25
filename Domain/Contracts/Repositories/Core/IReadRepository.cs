using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IFilterRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        System.Linq.IQueryable<TEntity> FilterBy(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> expression);
    }
}
