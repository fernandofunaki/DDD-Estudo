using IoC;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Adm.Facade;

namespace WebSite.Adm.App_Start
{
    public class NinjectDepencendyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;
        public NinjectDepencendyResolver(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public static void Initialize()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(new Ninject.Modules.INinjectModule[] { new WebSiteAdmModule(), new WebSiteModule() });
            //Passa para o MVC resolver as dependencias
            DependencyResolver.SetResolver(new NinjectDepencendyResolver(kernel));
        }

        public object GetService(Type serviceType)
        {
           return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
  

    public class WebSiteAdmModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            base.Bind<IBannerFacade>().To<BannerFacade>();
        }
    }
}