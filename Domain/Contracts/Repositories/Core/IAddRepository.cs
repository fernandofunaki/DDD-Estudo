using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAddRepository<in TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        void Add(TEntity entity);
    }
}
