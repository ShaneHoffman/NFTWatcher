using System.Net.Http.Json;

namespace NFTWatcherV1.Client.Services.GenieService
{
    public class GenieService : IGenieService
    {
        private readonly HttpClient _http;

        public GenieService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<Collection>> GetCollection(string collectionAddress)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Collection>>($"api/Genie/collection/{collectionAddress}");
            return result!;
        }

        public async Task<ServiceResponse<List<Listing>>> GetCollectionListings(string collectionAddress)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Listing>>>($"api/Genie/collection/listings/{collectionAddress}");
            return result!;
        }

        public async Task<ServiceResponse<List<Collection>>> GetCollections(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Collection>>>($"api/Genie/search/{searchText}");
            return result!;
        }
    }
}
