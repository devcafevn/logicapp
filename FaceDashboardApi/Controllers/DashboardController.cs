using FaceDashboardApi.Data;
using FaceDashboardApi.Dto;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace FaceDashboardApi.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        [HttpGet, Route("faces")]
        public async Task<IEnumerable<FaceDto>> AllFaces()
        {
            using (DashboardDbContext dbContext = new DashboardDbContext())
            {
                return await dbContext.Faces
                  .Select(x => new FaceDto
                  {
                      Id = x.Id,
                      FaceId = x.FaceId,
                      FileUrl = x.FileUrl,
                      Age = x.Age,
                      Gender = x.Gender,
                      Glassess = x.Glassess,
                      Smile = x.Smile,
                      Moustache = x.Moustache,
                      Beard = x.Beard,
                      Sideburns = x.Sideburns,
                      Pitch = x.Pitch,
                      Yaw = x.Yaw,
                      Roll = x.Roll,
                      FaceRectangleHeight = x.FaceRectangleHeight,
                      FaceRectangleLeft = x.FaceRectangleLeft,
                      FaceRectangleTop = x.FaceRectangleTop,
                      FaceRectangleWidth = x.FaceRectangleWidth
                  }).ToListAsync();
            }
        }

        [HttpGet, Route("faces/{id}")]
        public async Task<FaceDto> GetFaces(Guid id)
        {
            using (DashboardDbContext dbContext = new DashboardDbContext())
            {
                return await dbContext.Faces
                  .Select(x => new FaceDto
                  {
                      Id = x.Id,
                      FaceId = x.FaceId,
                      FileUrl = x.FileUrl,
                      Age = x.Age,
                      Gender = x.Gender,
                      Glassess = x.Glassess,
                      Smile = x.Smile,
                      Moustache = x.Moustache,
                      Beard = x.Beard,
                      Sideburns = x.Sideburns,
                      Pitch = x.Pitch,
                      Yaw = x.Yaw,
                      Roll = x.Roll,
                      FaceRectangleHeight = x.FaceRectangleHeight,
                      FaceRectangleLeft = x.FaceRectangleLeft,
                      FaceRectangleTop = x.FaceRectangleTop,
                      FaceRectangleWidth = x.FaceRectangleWidth
                  }).FirstAsync(x => x.FaceId == id);
            }
        }

        [HttpPost]
        [Route("message")]
        public async Task<IHttpActionResult> Send(ChatMessage message)
        {
            var hubConnection = new HubConnection("https://face-dashboard-api.azurewebsites.net/signalr");
            var proxy = hubConnection.CreateHubProxy("ChatHub");

            await hubConnection.Start();

            await proxy.Invoke("Send", hubConnection.ConnectionId, message.Text);

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateDashboard(FaceDto faceDto)
        {
            var hubConnection = new HubConnection("https://face-dashboard-api.azurewebsites.net/signalr");
            var proxy = hubConnection.CreateHubProxy("dashboard");

            await hubConnection.Start();

            await proxy.Invoke("UpdateDashboard", hubConnection.ConnectionId, faceDto);

            return Ok();
        }

        [HttpPost]
        [Route("~/api/feedback")]
        public IHttpActionResult PostFeedback([FromBody] FeedbackDto feedback)
        {
            return Ok(feedback);
        }
    }

    public class ChatMessage
    {
        public string Text { get; set; }
    }
}
