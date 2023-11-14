using DbConnection.DbEntities;

namespace DbConnection.Interfaces
{
    public interface IBinanceBidsService
    {
        Task<List<BinanceBidsEntity>> GetBinanceBidsAsync();
        Task<List<BinanceBidsEntity>> GetBinanceBidsByBinanceIdAsync(long id);
        Task<BinanceBidsEntity> GetBinanceBidsAsync(long id);
        Task<int> SaveBinanceBidsAsync(BinanceBidsEntity binanceBids);
    }
}
