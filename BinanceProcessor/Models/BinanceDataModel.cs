namespace BinanceProcessor.Models
{
    public class BinanceDataModel
    {
        public string EventType { get; set; }
        public long EventTime { get; set; }
        public string Symbol { get; set; }
        public long FirstUpdateIdInEvent { get; set; }
        public long FinalUpdateIdInEvent { get; set; }
        public string[][] BidsToBeUpdated { get; set; }
        public string[][] AsksToBeUpdated { get; set; }
    }
}
