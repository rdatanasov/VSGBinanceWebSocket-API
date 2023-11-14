namespace WebAPI.Models
{
    public class BinanceModel
    {
        public int ID { get; set; }
        public string EventType { get; set; }
        public DateTime EventTime { get; set; }
        public string Symbol { get; set; }
        public long FirstUpdateIdInEvent { get; set; }
        public long FinalUpdateIdInEvent { get; set; }

    }
}
