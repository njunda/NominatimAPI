using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nominatim.Clients.Models;

namespace Nominatim.Clients.Mapper
{
    public class AutomapperProfile : Profile
    {   
        public AutomapperProfile() {

            CreateMap<QuerySearchModel, StructuredQuerySearchModel>().ReverseMap();
        }
    }
}
