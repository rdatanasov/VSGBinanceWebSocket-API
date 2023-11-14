using DbConnection.DbEntities;

namespace DbConnection.Interfaces
{
    public interface IBinanceAsksService
    {
        Task<List<BinanceAsksEntity>> GetBinanceAsksAsync();
        Task<List<BinanceAsksEntity>> GetBinanceAsksByBinanceIdAsync(long id);
        Task<BinanceAsksEntity> GetBinanceAsksAsync(long id);
        Task<int> SaveBinanceAsksAsync(BinanceAsksEntity binanceAsks);
    }
}
