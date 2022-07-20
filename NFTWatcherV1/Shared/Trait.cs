using System;
namespace NFTWatcherV1.Shared
{
    public class Trait
    {
        public string trait_type { get; set; } = string.Empty;
        public string trait_value { get; set; } = string.Empty;
        public decimal? floorPrice { get; set; }
    }
}

