using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SPA_MVC_EmployeeInfo.Startup))]

namespace SPA_MVC_EmployeeInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
//            ConfigureAuth(app);
        }
    }
}
