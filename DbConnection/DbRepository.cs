using DbConnection.DbEntities;
using DbConnection.Interfaces;
using SQLite;

namespace DbConnection
{
    public class DbRepository : IBinanceService, IBinanceBidsService, IBinanceAsksService
    {
        readonly SQLiteAsyncConnection database;

        public DbRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<BinanceEntity>().Wait();
            database.CreateTableAsync<BinanceBidsEntity>().Wait();
            database.CreateTableAsync<BinanceAsksEntity>().Wait();

        }

        #region Binance
        public async Task<List<BinanceEntity>> GetBinancesAsync()
        {
            //Get all Binances.
            return await database.Table<BinanceEntity>().ToListAsync();
        }

        public async Task<BinanceEntity> GetBinanceAsync(int id)
        {
            // Get a specific binance.
            return await database.Table<BinanceEntity>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<List<BinanceEntity>> GetBinanceBySymbolAsync(string symbol)
        {
            // Get a specific binance.
            return await database.Table<BinanceEntity>()
                            .Where(i => i.Symbol == symbol)
                            .ToListAsync();
        }

        public async Task<int> SaveBinanceAsync(BinanceEntity binance)
        {
            // Save a new binance.
            var result = await database.InsertAsync(binance);

            if (result == 1)
            {
                var lastBinance = (await database.Table<BinanceEntity>().ToListAsync()).LastOrDefault();
                return lastBinance?.ID ?? 0;
            }

            return 0;
        }

        public async Task<int> DeleteBinanceAsync(BinanceEntity binance)
        {
            return await database.DeleteAsync(binance);
        }
        #endregion

        #region Binance Bids
        public async Task<List<BinanceBidsEntity>> GetBinanceBidsAsync()
        {
            return await database.Table<BinanceBidsEntity>().ToListAsync();
        }

        public async Task<List<BinanceBidsEntity>> GetBinanceBidsByBinanceIdAsync(long id)
        {
            return await database.Table<BinanceBidsEntity>()
                         .Where(i => i.BinanceID == id)
                         .ToListAsync();
        }

        public async Task<BinanceBidsEntity> GetBinanceBidsAsync(long id)
        {
            return await database.Table<BinanceBidsEntity>()
                          .Where(i => i.ID == id)
                          .FirstOrDefaultAsync();
        }

        public async Task<int> SaveBinanceBidsAsync(BinanceBidsEntity binanceBids)
        {
            return await database.InsertAsync(binanceBids);
        }
        #endregion

        #region Binance Asks
        public async Task<List<BinanceAsksEntity>> GetBinanceAsksAsync()
        {
            return await database.Table<BinanceAsksEntity>().ToListAsync();
        }

        public async Task<List<BinanceAsksEntity>> GetBinanceAsksByBinanceIdAsync(long id)
        {
            return await database.Table<BinanceAsksEntity>()
                         .Where(i => i.BinanceID == id)
                         .ToListAsync();
        }

        public async Task<BinanceAsksEntity> GetBinanceAsksAsync(long id)
        {
            return await database.Table<BinanceAsksEntity>()
                         .Where(i => i.ID == id)
                         .FirstOrDefaultAsync();
        }

        public async Task<int> SaveBinanceAsksAsync(BinanceAsksEntity binanceAsks)
        {
            return await database.InsertAsync(binanceAsks);
        }
        #endregion
    }
}
