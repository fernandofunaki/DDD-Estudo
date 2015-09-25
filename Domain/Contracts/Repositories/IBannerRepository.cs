using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IBannerRepository :
        IAddRepository<BannerEntity, int>,
        IUpdateRepository<BannerEntity, int>,
        IQueryRepository<BannerEntity, int>,
        IDeleteRepository<BannerEntity, int>,
         IReadSingleRepository<BannerEntity, int>
    {

    }
}
