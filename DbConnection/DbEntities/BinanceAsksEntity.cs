using SQLite;

namespace DbConnection.DbEntities
{
    [Table("BinanceAsks")]
    public class BinanceAsksEntity : EntityBase
    {
        [Indexed]
        public int BinanceID { get; set; }
        public string PriceLevel { get; set; }
        public string Quantity { get; set; }
    }
}
