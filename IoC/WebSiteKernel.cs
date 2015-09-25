using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class WebSiteKernel : Ninject.StandardKernel
    {
        public WebSiteKernel()
            : base(new WebSiteModule())
        {

        }
    }
}
