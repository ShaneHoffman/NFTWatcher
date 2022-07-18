namespace NFTWatcherV1.Server.Services.SearchService
{
    public interface IGenieService
    {
        Task<ServiceResponse<List<Collection>>> GetCollections(string searchText);
        Task<ServiceResponse<List<Listing>>> GetCollectionListings(string collectionAddress);
        Task<ServiceResponse<Collection>> GetCollection(string collectionAddress);
    }
}
