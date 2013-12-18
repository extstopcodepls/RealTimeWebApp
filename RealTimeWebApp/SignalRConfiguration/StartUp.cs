using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: Microsoft.Owin.OwinStartup(typeof(RealTimeWebApp.SignalRConfiguration.StartUp))]
namespace RealTimeWebApp.SignalRConfiguration
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}