
using Microsoft.EntityFrameworkCore;
using Nominatim.Clients.Models;

namespace Nominatim.Clients.Context
{
    public class NominatimDbContext : DbContext
    {
        public NominatimDbContext(DbContextOptions<NominatimDbContext> options) : base(options) { }

        public DbSet<QuerySearchModel> QuerySearchModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
