namespace NFTWatcherV1.Client.Services.SearchService
{
    public interface ISearchService
    {
        Task<ServiceResponse<List<CollectionFromSearch>>> SearchCollections(string searchText);
    }
}
