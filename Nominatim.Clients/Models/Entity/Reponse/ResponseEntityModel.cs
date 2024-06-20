using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nominatim.Clients.Enums;
using Nominatim.Clients.Models.Entity.Base;
using Nominatim.Clients.Models.Entity.Query;
using Nominatim.Clients.Models.Entity.QueryResponse;

namespace Nominatim.Clients.Models.Entity.Reponse
{  
    /// <summary>
    /// This class stores just response status of the search Query. 
    /// And has  one to n relation with the Reponse.
    /// </summary>
    public sealed class ResponseEntityModel : BaseEntityModel, IEntityTypeConfiguration<ResponseEntityModel>
    {  
        /// <summary>
        /// This stores the status code for the error message
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// This stores the error Message 
        /// </summary>
        public string? ErrorMessage { get; private set; }

        /// <summary>
        /// This is the foreign key for the Query Search. 
        /// </summary>
        public Guid QuerySearchModelId { get; private set; }

        /// <summary>
        /// The navigation parameter. 
        /// </summary>
        public QuerySearchModel? QuerySearchModel { get; private set; }

        /// <summary>
        /// This holds the list of the response messages. 
        /// </summary>
        public List<QueryResponseEntityModel> QueryResponseEntityModels { get; private set; } = new List<QueryResponseEntityModel>();


        public void Configure(EntityTypeBuilder<ResponseEntityModel> builder)
        {
            // eins to eins beziehung
            builder.HasOne<QuerySearchModel>(y => y.QuerySearchModel)
               .WithMany()
               .HasForeignKey(x => x.QuerySearchModelId);

            /// This is needed by entity Framework to save Enums as strings 
            /// and converts the enums to and from strings when reading and writing to the database. 
            ValueConverter<Status, string> StatusConverter = new ValueConverter<Status, string>
                (v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v)
                 );
        }
    }
}
