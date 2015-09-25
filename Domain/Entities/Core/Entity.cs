using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Entity<TId> where TId : struct
    {
        public virtual TId Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }

        public Entity()
        {
            this.CreatedAt = DateTime.Now;
        }

    }
}
