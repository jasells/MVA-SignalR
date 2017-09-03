using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.SignalR.Client.Hubs;
using XamarinMoveShape.Models;

namespace Xamarin.SignalRClient
{
    public class ConnectionFactory: XamarinMoveShape.Models.IConnectionFactory
    {

        public Microsoft.AspNet.SignalR.Client.HubConnection Conn { get; private set; }

        public string ServerURL { get { return XamarinMoveShape.Models.Constants.server; } }

        public ConnectionFactory()
        {
            Conn = new Microsoft.AspNet.SignalR.Client.HubConnection(ServerURL);

            //Conn.Start().ContinueWith((t) =>
            //{
            //    //a place to do something @ start up... like initial call to srvr

            //});
        }
    }
}
