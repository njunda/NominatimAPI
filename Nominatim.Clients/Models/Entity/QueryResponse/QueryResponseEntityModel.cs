using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nominatim.Clients.Models.Entity.Base;
using Nominatim.Clients.Models.Entity.Reponse;

namespace Nominatim.Clients.Models.Entity.QueryResponse
{   
    /// <summary>
    ///  The class to store the response from the Query. 
    /// </summary>
    public sealed class QueryResponseEntityModel : BaseEntityModel , IEntityTypeConfiguration<QueryResponseEntityModel>
    {
      
        public int PlaceId { get; private set; }

        public string Licence { get; private set; } 

        public string OsmType { get; private set; }

        public long OsmId { get; private set; }

        public string Lat { get; private set; }

        public string Lon { get; private set; }

        public string Category { get; private set; }

        public string Type { get; private set; }

        public int PlaceRank { get; private set; }

        public double Importance { get; private set; }

        public string Addresstype { get; private set; }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }

        public List<string> Boundingbox { get; private set; }

        /// <summary>
        /// The Foreign - key for the Response Entity   
        /// </summary>
        public Guid ResponseEntityModelId { get; private set; }


        public ResponseEntityModel ResponseEntity { get; private set; }


        public void Configure(EntityTypeBuilder<QueryResponseEntityModel> builder)
        {
            // jede Response hat ein M Resonses
            builder.HasOne<ResponseEntityModel>(y => y.ResponseEntity)
                 .WithMany(b => b.QueryResponseEntityModels)
                 .HasForeignKey(z => z.ResponseEntityModelId);
        }
    }
}
