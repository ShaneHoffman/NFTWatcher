namespace NFTWatcherV1.Server.Services.SearchService
{
    public interface ISearchService
    {
        Task<ServiceResponse<List<CollectionFromSearch>>> SearchCollections(string searchText);
    }
}
