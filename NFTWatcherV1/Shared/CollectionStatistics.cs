using System;
namespace NFTWatcherV1.Shared
{
    public class CollectionStatistics
    {
        public decimal average_price { get; set; }
        public int one_day_sales { get; set; }
        public decimal one_day_volume { get; set; }
        public decimal seven_day_change { get; set; }
        public int seven_day_sales { get; set; }
        public decimal seven_day_volume { get; set; }
    }
}

