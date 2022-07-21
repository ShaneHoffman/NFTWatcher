using System;
namespace NFTWatcherV1.Shared
{
    public class Trait
    {
        public string trait_type { get; set; } = string.Empty;
        public Object trait_value { get; set; } = new Object();
        public decimal? floorPrice { get; set; }
    }
}

