using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nominatim.Clients.Context;
using Nominatim.Clients.Enums;
using Nominatim.Clients.Models;
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
        public async Task<IActionResult> Search([FromBody] StructuredQuerySearchModel searchModel)
        {
            var response = await _nominatimClient.Search(searchModel);

            var rest = _mapper.Map<QuerySearchModel>(searchModel);

            //var searchQuery = new SearchQuery
            //{
            //    Query = searchModel.Query,
            //    Response = JsonSerializer.Serialize(response.ApiResponse),
            //    QueryDate = DateTime.UtcNow
            //};

            _context.QuerySearchModels.Add(rest);
            await _context.SaveChangesAsync();

            return response.Status == Status.Success ? Ok(response.ApiResponse) : StatusCode(500, response.ErrorMessage);
        }

        [HttpGet]
        public IActionResult GetRecentQueries()
        {
            var recentQueries = _context.QuerySearchModels
                .Take(10)
                .ToList();
            return Ok(recentQueries);
        }


    }
}
