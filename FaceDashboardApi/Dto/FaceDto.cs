using System;

namespace FaceDashboardApi.Dto
{
    public class FaceDto
    {
        public int Id { get; set; }

        public Guid FaceId { get; set; }

        public string FileUrl { get; set; }

        public decimal Age { get; set; }

        public string Gender { get; set; }

        public string Glassess { get; set; }

        public decimal Smile { get; set; }

        public decimal Moustache { get; set; }

        public decimal Beard { get; set; }

        public decimal Sideburns { get; set; }

        public decimal Pitch { get; set; }

        public decimal Yaw { get; set; }

        public decimal Roll { get; set; }

        public decimal FaceRectangleHeight { get; set; }

        public decimal FaceRectangleLeft { get; set; }

        public decimal FaceRectangleTop { get; set; }

        public decimal FaceRectangleWidth { get; set; }
    }
}