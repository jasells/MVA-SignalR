using System;
using System.Threading.Tasks;

namespace XamarinMoveShape.Models
{
    public class Item : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        Location loc;
        public Location Location
        {
            get { return loc; }
            set { SetProperty(ref loc, value); }
        }

        public Item()
        {
            loc = lastLoc;

            LocationRx += (sender, args) => Location = args;
        }

        static Microsoft.AspNet.SignalR.Client.HubConnection conn;
        static Microsoft.AspNet.SignalR.Client.IHubProxy hub;

        static Item()
        {
            lastLoc = new Location() { X = 0, Y = 0 };

            //conn = Xamarin.Forms.DependencyService.Get<IConnectionFactory>().Conn;
            conn = new Microsoft.AspNet.SignalR.Client.HubConnection(XamarinMoveShape.Models.Constants.server);
            hub = conn.CreateHubProxy(Constants.HubName);

            hub.Subscribe(Constants.ShapeMoved).Received += RemoteMoveRx;

            conn.Start().ContinueWith((t) =>
            {
                //check the server for last state to do initial sync?
            });
        }
        private static event EventHandler<Location> LocationRx;

        static Location lastLoc;

        private static void RemoteMoveRx(System.Collections.Generic.IList<global::Newtonsoft.Json.Linq.JToken> obj)
        {
            LocationRx?.Invoke(null, lastLoc = new XamarinMoveShape.Models.Location()
            {
                X = (double)obj[0],
                Y = (double)obj[1]
            });
        }

    }
}