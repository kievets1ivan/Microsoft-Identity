using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: OwinStartup(typeof(Authorizing.App_Start.Startup))]

namespace Authorizing.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurationAuth(app);
        }
    }
}