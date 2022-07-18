using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTWatcherV1.Shared
{
    public class GenieResult<T>
    {
        public int code { get; set; }
        public List<T> data { get; set; } = new List<T>();
    }
}
