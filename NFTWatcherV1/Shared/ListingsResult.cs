using System;
namespace NFTWatcherV1.Shared
{
    public class ListingsResult
    {
        public int code { get; set; }
        public List<Listing> data { get; set; } = new List<Listing>();
    }
}

