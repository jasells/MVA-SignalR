using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.SignalRClient
{
    public static class DepencyInjection
    {
        /// <summary>
        /// A central place to set up the depency injection for all platforms
        /// </summary>
        public static void Register()
        {
            Xamarin.Forms.DependencyService.Register<XamarinMoveShape.Models.IConnectionFactory, Xamarin.SignalRClient.ConnectionFactory>();

        }
    }
}
