using System;
namespace NFTWatcherV1.Client.Services.BrowserService
{
    public interface IBrowserServcie
    {
        Task<BrowserDimensions> GetDimensions();
    }
}

