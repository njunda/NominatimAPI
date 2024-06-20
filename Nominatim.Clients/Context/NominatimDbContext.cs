
using Microsoft.EntityFrameworkCore;
using Nominatim.Clients.Models.Entity.Query;
using Nominatim.Clients.Models.Entity.QueryResponse;
using Nominatim.Clients.Models.Entity.Reponse;

namespace Nominatim.Clients.Context
{
    public class NominatimDbContext : DbContext
    {
        public NominatimDbContext(DbContextOptions<NominatimDbContext> options) : base(options) { }

        public DbSet<QuerySearchModel> QuerySearchModels { get; set; }

        public DbSet<QueryResponseEntityModel> QueryResponseEntityModels { get; set; }

        public DbSet<ResponseEntityModel> ResponseEntityModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
