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

        static Microsoft.AspNet.SignalR.Client.HubConnection conn;
        static Microsoft.AspNet.SignalR.Client.IHubProxy hub;

        static Item()
        {
            conn = new Microsoft.AspNet.SignalR.Client.HubConnection("http://localhost:24421/");

            hub = conn.CreateHubProxy( "moveShape");

            

            Task.Run(async () =>
           {
               //this writes an exception to debug!
               //var t = conn.Start();
               int i;
               var t = new Task(() => i = 0);

               t.Start();

               await t;
               hub.Subscribe("MoveShape").Received += RemoteMoveRx;

           });
        }

        static int lastX, lastY;

        private static void RemoteMoveRx(System.Collections.Generic.IList<global::Newtonsoft.Json.Linq.JToken> obj)
        {
            lastX = 0;
        }

        int x;
        public int X
        {
            get { return x; }
            set { SetProperty(ref x, value); }
        }

        int y;
        public int Y
        {
            get { return y; }
            set { SetProperty(ref y, value); }
        }
    }
}