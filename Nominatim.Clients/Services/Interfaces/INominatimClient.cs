using Nominatim.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominatim.Clients.Services.Interfaces
{
    public interface INominatimClient
    {
        Task<RequestResponseModel> Search(StructuredQuerySearchModel searchModel);
    }
}
