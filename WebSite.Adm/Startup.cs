using Microsoft.Owin;
using Owin;
using System;
using System.Globalization;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebSite.Adm.App_Start;

[assembly: OwinStartupAttribute(typeof(WebSite.Adm.Startup))]
namespace WebSite.Adm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            NinjectDepencendyResolver.Initialize();
        }
    }

    


}
