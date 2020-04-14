using System;
using System.Threading;
using System.Threading.Tasks;
using Firstcod.FC.WebAssemblyCRUD.Client.Pages.Customer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

namespace Firstcod.FC.WebAssemblyCRUD.Server.Connector
{
    public class HubConnector : Hub<IHubConnector>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
