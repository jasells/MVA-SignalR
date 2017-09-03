using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MoveShape
{
    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public void Init()
        {
        }

        public void MoveShape(double x, double y)
        {
            Clients.Others.shapeMoved(x, y);
        }

        public override Task OnConnected()
        {
            System.Diagnostics.Debug.WriteLine("client connected");

            return base.OnConnected();
        }
    }
}