using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTWatcherV1.Shared
{
    public class CollectionFromSearch
    {
        public string address { get; set; } = string.Empty;
        public string bannerImageUrl { get; set; } = string.Empty;
        public decimal? floorPrice { get; set; }
        public string imageUrl { get; set; } = string.Empty;
        public bool isVerified { get; set; }
        public string Name { get; set; } = string.Empty;
        public CollectionStatistics stats { get; set; } = new CollectionStatistics();
        public int totalSupply { get; set; }
    }
}
