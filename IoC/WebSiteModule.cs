using Adapters;
using Adapters.DataMapper;
using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class WebSiteModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            base.Bind<IContext>().To<WebSiteContext>().InThreadScope();
            base.Bind<IUnitOfWork>().To<UnitOfWork<WebSiteContext>>();
            base.Bind<ITypeAdapter>().To<AdapterAutoMapper>();
            base.Bind<IBannerRepository>().To<BannerRepository>();
            base.Bind<Mail.IMailSender>().To<Mail.Gmail.ISenderGmail>();
        }
    }
}
