using System.Net.Http.Json;

namespace NFTWatcherV1.Client.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _http;

        public SearchService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<List<CollectionFromSearch>>> SearchCollections(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<CollectionFromSearch>>>($"api/search/{searchText}");
            return result!;
        }
    }
}
