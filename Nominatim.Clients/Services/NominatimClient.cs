using Nominatim.Clients.Enums;
using Nominatim.Clients.Models.DTO.Query;
using Nominatim.Clients.Models.DTO.QueryResponse;
using Nominatim.Clients.Models.DTO.Response;
using Nominatim.Clients.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Nominatim.Clients.Services
{
    public class NominatimClient : INominatimClient
    {
        private const string BaseUri = "https://nominatim.openstreetmap.org/search?q=";
        private const string Format = "&format=jsonv2";

        private readonly HttpClient _httpClient;


        public NominatimClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# NominatimClient");
        }

        public async Task<ResponseDTOModel> Search(StructuredQuerySearchDTOModel searchModel)
        {

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# NominatimClient");

            // Build the request URL with the query
            var requestUrl = $"{BaseUri}{searchModel}{Format}";

            // Send the GET request and get the response
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                var deserializedResponse = JsonSerializer.Deserialize<List<QueryResponseDTOModel>>(apiResponse);

                return new ResponseDTOModel
                {
                    Status = Status.Success,
                    ApiResponse = deserializedResponse ?? []
                };
            }
            else
            {
                return new ResponseDTOModel
                {
                    Status = Status.Error,
                    ErrorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}"
                };
            }
        }
    }
}
