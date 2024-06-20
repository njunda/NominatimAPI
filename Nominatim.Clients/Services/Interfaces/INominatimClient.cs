using Nominatim.Clients.Models.DTO.Query;
using Nominatim.Clients.Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominatim.Clients.Services.Interfaces
{
    public interface INominatimClient
    {
        Task<ResponseDTOModel> Search(StructuredQuerySearchDTOModel searchModel);
    }
}
