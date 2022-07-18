using System;
namespace NFTWatcherV1.Shared
{
    public class Listing
    {
        public string baseCurrency { get; set; } = string.Empty;
        public string basePrice { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
        public string marketplace { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public bool openseaSusFlag { get; set; } = false;
        public string tokenId { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }
}

