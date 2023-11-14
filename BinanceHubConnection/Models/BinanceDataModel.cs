using Newtonsoft.Json;

namespace BinanceHubConnection.Models
{
    public class BinanceDataModel
    {
        // Event type
        [JsonProperty("e")]
        public string EventType { get; set; }

        // Event time
        [JsonProperty("E")]
        public long EventTime { get; set; }

        // Symbol
        [JsonProperty("s")]
        public string Symbol { get; set; }

        // First update ID in event
        [JsonProperty("U")]
        public long FirstUpdateIdInEvent { get; set; }

        // Final update ID in event
        [JsonProperty("u")]
        public long FinalUpdateIdInEvent { get; set; }

        // Bids to be updated": [0][0] - // Price level to be updated ; [0][1] - // Quantity
        [JsonProperty("b")]
        public string[][] BidsToBeUpdated { get; set; }

        // Asks to be updated: [0][0] - // Price level to be updated ; [0][1] - // Quantity
        [JsonProperty("a")]
        public string[][] AsksToBeUpdated { get; set; }
    }
}
