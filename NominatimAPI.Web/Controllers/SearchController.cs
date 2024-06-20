using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nominatim.Clients.Context;
using Nominatim.Clients.Enums;
using Nominatim.Clients.Models.DTO.Query;
using Nominatim.Clients.Models.Entity.Query;
using Nominatim.Clients.Models.Entity.QueryResponse;
using Nominatim.Clients.Models.Entity.Reponse;
using Nominatim.Clients.Services.Interfaces;
using System.Text.Json;

namespace NominatimAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly INominatimClient _nominatimClient;
        private readonly NominatimDbContext _context;
        private readonly ILogger<SearchController> _logger;
        private readonly IMapper _mapper;

        public SearchController(INominatimClient nominatimClient, NominatimDbContext context,IMapper mapper,  ILogger<SearchController> logger)
        {
            _nominatimClient = nominatimClient;
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Search([FromBody] StructuredQuerySearchDTOModel searchModel)
        {
            var response = await _nominatimClient.Search(searchModel);

            StructuredMinimisedQuerySearchDTOModel line2 = _mapper.Map<StructuredMinimisedQuerySearchDTOModel>(searchModel);
            line2.ResponseDTO = response;

            QuerySearchModel querySearchModel = _mapper.Map<QuerySearchModel>(line2);


            ResponseEntityModel ReponseModels = _mapper.Map<ResponseEntityModel>(response);


            querySearchModel.SetQueryResponse(ResponseEntityModel);

            _context.QuerySearchModels.Add(querySearchModel);
            await _context.SaveChangesAsync();

            return response.Status == Status.Success ? Ok(response.ApiResponse) : StatusCode(500, response.ErrorMessage);
        }

        [HttpGet]
        public IActionResult GetRecentQueries()
        {
            List<QuerySearchModel> recentQueries = _context.QuerySearchModels.Include(b => b.ResponseEntityModel)
                                                                              .ThenInclude( x=> x.QueryResponseEntityModels)
                .Take(5)
                .ToList();
            return Ok(_mapper.Map<List<StructuredMinimisedQuerySearchDTOModel>>(recentQueries));
        }


    }
}
