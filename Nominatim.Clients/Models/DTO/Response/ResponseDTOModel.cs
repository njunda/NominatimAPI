using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Nominatim.Clients.Enums;
using Nominatim.Clients.Models.DTO.QueryResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nominatim.Clients.Models.DTO.Response
{
    public class ResponseDTOModel
    {
        public Status Status { get; set; }
        public string? ErrorMessage { get; set; }

        public List<QueryResponseDTOModel> ApiResponse { get; set; }
    }
}
