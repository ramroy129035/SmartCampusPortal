using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}