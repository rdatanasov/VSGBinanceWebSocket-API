using BinanceProcessor.Models;
using DbConnection.DbEntities;

namespace BinanceProcessor
{
    public class BinanceProcessor
    {
        /// <summary>
        /// method accept binance data and save it to the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Process(BinanceDataModel data)
        {
            try
            {
                var binanceEntity = BuildBinanceEntity(data);

                var binanceId = await DbConnection.DataConnection.Database.SaveBinanceAsync(binanceEntity);

                if (binanceId > 0)
                {
                    await ProcessBids(binanceId, data);
                    await ProcessAsks(binanceId, data);
                }
            }
            catch (Exception ex)
            {
                //TODO: Utilize a logging framework like Serilog, NLog, or log4net
                //logger.Error(ex, "An error occurred: {ErrorMessage}", ex.Message);
            }
        }

        private static BinanceEntity BuildBinanceEntity(BinanceDataModel data)
        {
            long unixTimestampMilliseconds = data.EventTime;

            DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestampMilliseconds).DateTime;

            return new BinanceEntity()
            {
                ID = 0,
                EventType = data.EventType,
                EventTime = dateTime,
                Symbol = data.Symbol,
                FirstUpdateIdInEvent = data.FirstUpdateIdInEvent,
                FinalUpdateIdInEvent = data.FinalUpdateIdInEvent,
            };
        }


        /// <summary>
        /// method accept bids for specific binace and save it to data base
        /// </summary>
        /// <param name="binanceId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task ProcessBids(int binanceId, BinanceDataModel data)
        {
            for (int i = 0; i < data.BidsToBeUpdated.Length; i++)
            {
                string[] bids = data.BidsToBeUpdated[i];
                var priceLevel = bids[0];
                var quantity = bids[1];

                var entity = new BinanceBidsEntity() { ID = 0, BinanceID = binanceId, PriceLevel = priceLevel, Quantity = quantity };

                await DbConnection.DataConnection.Database.SaveBinanceBidsAsync(entity);

                var counter = 1;

                if (counter == 1)
                {
                    Console.WriteLine($"BIDS  BinanceID {entity.BinanceID}");
                    counter++;
                }
            }
        }


        /// <summary>
        /// method accept asks for specific binace and save it to data base
        /// </summary>
        /// <param name="binanceId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task ProcessAsks(int binanceId, BinanceDataModel data)
        {
            for (int i = 0; i < data.AsksToBeUpdated.Length; i++)
            {
                string[] asks = data.BidsToBeUpdated[i];
                var priceLevel = asks[0];
                var quantity = asks[1];

                var entity = new BinanceAsksEntity() { ID = 0, BinanceID = binanceId, PriceLevel = priceLevel, Quantity = quantity };

                await DbConnection.DataConnection.Database.SaveBinanceAsksAsync(entity);
            }

        }
    }
}