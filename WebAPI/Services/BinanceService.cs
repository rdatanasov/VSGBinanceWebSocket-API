using DbConnection.DbEntities;

namespace WebAPI.Services
{
    public class BinanceDataService : IBinanceDataService
    {
        public async Task<decimal> Get24hAvgPrice(string symbol)
        {
            var entities = await DbConnection.DataConnection.Database.GetBinanceBySymbolAsync(symbol);

            if (entities == null)
            {
                return 0.0m;
            }

            var binances = GetLast24Hours(entities);

            var prices = new List<decimal>();

            if (binances == null)
            {
                return 0.0m;
            }

            foreach (var binance in binances)
            {
                //TODO use Bids price level to calculate Average prices because it is unclear which prices should be used Bids OR Asks
                var binancePrices = await DbConnection.DataConnection.Database.GetBinanceBidsByBinanceIdAsync(binance.ID);

                foreach (var binancePrice in binancePrices)
                {
                    if (decimal.TryParse(binancePrice.PriceLevel, out decimal value))
                    {
                        prices.Add(value);
                    }
                }
            }

            if (prices.Count > 0)
            {
                return prices.Average();
            }
            return 0.0m;
        }

        private List<BinanceEntity> GetLast24Hours(List<BinanceEntity> allItems)
        {
            DateTime twentyFourHoursAgo = DateTime.UtcNow.AddHours(-24);
            return allItems.Where(item => item.EventTime >= twentyFourHoursAgo).ToList();
        }
    }
}
