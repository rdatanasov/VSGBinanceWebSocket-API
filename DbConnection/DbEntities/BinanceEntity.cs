using SQLite;

namespace DbConnection.DbEntities
{
    [Table("Binances")]
    public class BinanceEntity : EntityBase
    {
        public string EventType { get; set; }
        public DateTime EventTime { get; set; }
        public string Symbol { get; set; }
        public long FirstUpdateIdInEvent { get; set; }
        public long FinalUpdateIdInEvent { get; set; }
    }
}
