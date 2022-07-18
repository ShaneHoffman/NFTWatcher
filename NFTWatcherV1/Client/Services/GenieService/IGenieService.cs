namespace NFTWatcherV1.Client.Services.SearchService
{
    public interface IGenieService
    {
        Task<ServiceResponse<List<Collection>>> GetCollections(string searchText);
    }
}
