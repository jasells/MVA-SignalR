using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMoveShape.Models
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return string.Concat("(", X, ",", Y, ")");
        }
    }

    public interface IConnectionFactory
    {
        string ServerURL { get; }

        Microsoft.AspNet.SignalR.Client.HubConnection Conn { get;  }
    }

    public static class Constants
    {
        public const string server = "http://localhost:24421/";
    }
}
