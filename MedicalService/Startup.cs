using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using DataLayer.MedicalDatabase;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(MedicalService.Startup))]

namespace MedicalService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        { 
            ConfigureAuth(app);
        }
    }
}
