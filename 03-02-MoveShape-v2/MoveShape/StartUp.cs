using Microsoft.Owin;
using Owin;
using System.Web;

//allows asp boostrap to find our initializer (plugin) for signalR
[assembly: OwinStartup(typeof(MoveShape.Startup))]

namespace MoveShape
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}