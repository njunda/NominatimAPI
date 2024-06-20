using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nominatim.Clients.Models.Entity.Base;
using Nominatim.Clients.Models.Entity.QueryResponse;
using Nominatim.Clients.Models.Entity.Reponse;

namespace Nominatim.Clients.Models.Entity.Query
{
    public sealed class QuerySearchModel : BaseEntityModel, IEntityTypeConfiguration<QuerySearchModel>
    {
        #region Class base Properties Properties
        public string Amenity { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }


        /// <summary>
        /// this is the navigation property for the current Query Response.
        /// </summary>
        public ResponseEntityModel? ResponseEntityModel { get; private set; }

        #endregion


        /// <summary>
        /// this sets the query Rersponse. 
        /// </summary>
        /// <param name="queryResponseEntityModel"></param>
        public void SetQueryResponse(ResponseEntityModel? queryResponseEntityModel)
        {
            this.ResponseEntityModel = queryResponseEntityModel;
        }


        #region Build the relationships

        public void Configure(EntityTypeBuilder<QuerySearchModel> builder)
        {
        }

        #endregion

    }
}