﻿using System.Net.Http.Headers;

namespace NFTWatcherV1.Server.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _http;

        public SearchService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<List<Listing>>> CollectionListings(string collectionAddress)
        {
            var response = new ServiceResponse<List<Listing>>();

            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://genie-production-api.herokuapp.com/assets");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

            request.Content = new StringContent("{\"filters\":{\"address\":\"" + collectionAddress +
                "\",\"traits\":{},\"searchText\":\"\",\"notForSale\":false,\"numTraits\":[]},\"fields\":" +
                "{\"address\":1,\"name\":1,\"id\":1,\"imageUrl\":1,\"currentPrice\":1,\"currentUsdPrice\":1,\"" +
                "paymentToken\":1,\"animationUrl\":1,\"notForSale\":1,\"rarity\":1,\"tokenId\":1},\"limit\":25,\"offset\":0,\"markets\":[]}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            try
            {
                var result = await _http.SendAsync(request);
                var listingsResult = await result.Content.ReadFromJsonAsync<ListingsResult>();

                if (listingsResult is not null)
                    response.Data = listingsResult.data;
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

        public async Task<ServiceResponse<CollectionFromSearch>> GetCollection(string collectionAddress)
        {
            var response = new ServiceResponse<CollectionFromSearch>();

            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://genie-production-api.herokuapp.com/collections");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

            request.Content = new StringContent("{\"filters\":{\"address\":\"" + collectionAddress +
                "\"},\"limit\":1,\"fields\":{\"traits\":1,\"stats\":1,\"indexingStats.openSea\":1,\"imageUrl\":1," +
                "\"bannerImageUrl\":1,\"twitter\":1,\"externalUrl\":1,\"instagram\":1,\"discordUrl\":1,\"marketplaceCount\":1,\"floorPrice\":1},\"offset\":0}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            try
            {
                var result = await _http.SendAsync(request);
                var searchResult = await result.Content.ReadFromJsonAsync<SearchResult>();

                if (searchResult is not null)
                    response.Data = searchResult.data.ElementAt(0);
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

        public async Task<ServiceResponse<List<CollectionFromSearch>>> SearchCollections(string searchText)
        {
            var response = new ServiceResponse<List<CollectionFromSearch>>();

            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://genie-production-api.herokuapp.com/searchCollections");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

            request.Content = new StringContent("{\"filters\":{\"$or\":[{\"name\":{\"$regex\":\"" + 
                searchText + "\",\"$options\":\"i\"}}]},\"limit\":8,\"fields\":{\"name\":1,\"" + 
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
