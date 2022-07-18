using System.Net.Http.Json;

namespace NFTWatcherV1.Client.Services.SearchService
{
    public class GenieService : IGenieService
    {
        private readonly HttpClient _http;

        public GenieService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<List<Collection>>> GetCollections(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Collection>>>($"api/genie/{searchText}");
            return result!;
        }
    }
}
