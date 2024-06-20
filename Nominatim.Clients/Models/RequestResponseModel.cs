using Nominatim.Clients.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominatim.Clients.Models
{
    public class RequestResponseModel
    {
        public Status Status { get; set; }
        public string? ErrorMessage { get; set; }

        public List<ApiResponseModel> ApiResponse { get; set; }
    }
}
