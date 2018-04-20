using FaceDashboardApi.Dto;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FaceDashboardApi.Hubs
{
    [HubName("dashboard")]
    public class DashboardHub : Hub
    {
        public void UpdateDashboard(string name, FaceDto face)
        {
            Clients.All.updateDashboard(name, face);
        }
    }
}