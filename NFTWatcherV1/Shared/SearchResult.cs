using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTWatcherV1.Shared
{
    public class SearchResult
    {
        public int code { get; set; }
        public List<CollectionFromSearch> data { get; set; } = new List<CollectionFromSearch>();
    }
}
