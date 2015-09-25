using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDeleteRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        void Delete(TId id);
    }
}
