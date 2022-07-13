using System.Net.Http.Headers;

namespace NFTWatcherV1.Server.Services.SearchService
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
            var response = new ServiceResponse<List<CollectionFromSearch>>();

            if (string.IsNullOrEmpty(searchText))
            {
                response.Success = false;
                response.Message = "Search text is null or empty.";
                return response;
            }

            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://genie-production-api.herokuapp.com/searchCollections");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

            request.Content = new StringContent("{\"filters\":{\"$or\":[{\"name\":{\"$regex\":\"" + 
                searchText + "\",\"$options\":\"i\"}}]},\"limit\":5,\"fields\":{\"name\":1,\"" + 
                "imageUrl\":1,\"address\":1,\"floorPrice\":1},\"offset\":0}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            try
            {
                var result = await _http.SendAsync(request);
                var searchResult = await result.Content.ReadFromJsonAsync<SearchResult>();

                if (searchResult is not null)
                    response.Data = searchResult.data;
                else
                {
                    response.Success = false;
                    response.Message = "Result is null.";
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                response.Success = false;
                response.Message = $"Error making request: {e}";
            }

            return response;
        }
    }
}
