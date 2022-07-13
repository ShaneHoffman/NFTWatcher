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
        public double? floorPrice { get; set; }
        public string imageUrl { get; set; } = string.Empty;
        public bool isVerified { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
