namespace NFTWatcherV1.Server.Services.SearchService
{
    public interface ISearchService
    {
        Task<ServiceResponse<List<CollectionFromSearch>>> SearchCollections(string searchText);
        Task<ServiceResponse<List<Listing>>> CollectionListings(string collectionAddress);
        Task<ServiceResponse<CollectionFromSearch>> GetCollection(string collectionAddress);
    }
}
