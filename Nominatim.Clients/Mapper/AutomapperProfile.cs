using AutoMapper;
using Nominatim.Clients.Models.DTO.Query;
using Nominatim.Clients.Models.DTO.QueryResponse;
using Nominatim.Clients.Models.DTO.Response;
using Nominatim.Clients.Models.Entity;
using Nominatim.Clients.Models.Entity.Query;
using Nominatim.Clients.Models.Entity.QueryResponse;
using Nominatim.Clients.Models.Entity.Reponse;

namespace Nominatim.Clients.Mapper
{
    public class AutomapperProfile : Profile
    {   
        public AutomapperProfile() {

            CreateMap<StructuredMinimisedQuerySearchDTOModel, StructuredQuerySearchDTOModel>().ReverseMap();
            CreateMap<QuerySearchModel,StructuredQuerySearchDTOModel>().ReverseMap();

            CreateMap<ResponseDTOModel, ResponseEntityModel>()
                .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.ErrorMessage))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.QueryResponseEntityModels, opt => opt.MapFrom(src => src.ApiResponse)).ReverseMap();
            ;

            CreateMap<QueryResponseEntityModel, QueryResponseDTOModel>().ReverseMap();

            CreateMap<QuerySearchModel, StructuredMinimisedQuerySearchDTOModel>()
              .ForMember(dest => dest.ResponseDTO, opt => opt.MapFrom(src => src.ResponseEntityModel));

            CreateMap<StructuredMinimisedQuerySearchDTOModel, QuerySearchModel>()
              .ForMember(dest => dest.ResponseEntityModel, opt => opt.MapFrom(src => src.ResponseDTO));

            CreateMap<GeneralResponseDTO, QuerySearchModel>();
        }
    }
}
