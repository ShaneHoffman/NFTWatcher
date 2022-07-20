namespace NFTWatcherV1.Client.Services.GenieService
{
    public interface IGenieService
    {
        Task<ServiceResponse<List<Collection>>> GetCollections(string searchText);
        Task<ServiceResponse<List<Listing>>> GetCollectionListings(string collectionAddress);
        Task<ServiceResponse<Collection>> GetCollection(string collectionAddress);
    }
}
