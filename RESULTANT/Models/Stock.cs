using Newtonsoft.Json;
using System;

namespace Resultant.Models
{

    public class Stock
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public Price Price { get; set; }
        [JsonProperty("percent_change")]
        public float PercentChange { get; set; }
        [JsonProperty("volume")]
        public int Volume { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

    }

    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public float Amount { get; set; }
    }

    public class StockJson
    {
        [JsonProperty("stock")]
        public Stock[] Stock { get; set; }
        [JsonProperty("as_of")]
        public DateTime AsOf { get; set; }
    }
}