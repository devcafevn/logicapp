using FaceDashboardApi.Models;
using System.Data.Entity;

namespace FaceDashboardApi.Data
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Face> Faces { get; set; }
    }
}