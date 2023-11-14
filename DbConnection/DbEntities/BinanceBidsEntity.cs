using SQLite;

namespace DbConnection.DbEntities
{
    [Table("BinanceBids")]
    public class BinanceBidsEntity : EntityBase
    {
        [Indexed]
        public int BinanceID { get; set; }
        public string PriceLevel { get; set; }
        public string Quantity { get; set; }
    }
}
