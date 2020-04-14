using Firstcod.FC.WebAssemblyCRUD.Client.Pages.Customer;
using Firstcod.FC.WebAssemblyCRUD.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firstcod.FC.WebAssemblyCRUD.Server.Connector
{
    public interface IHubConnector
    {
        Task Notify(string message = null);
    }
}
