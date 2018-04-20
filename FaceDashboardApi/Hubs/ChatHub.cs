using Microsoft.AspNet.SignalR;

namespace FaceDashboardApi.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.messageBroadcasted(name, message);
        }
    }
}