using DbConnection.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.Interfaces
{
    public interface IBinanceService
    {
        Task<List<BinanceEntity>> GetBinancesAsync();
        Task<BinanceEntity> GetBinanceAsync(int id);
        Task<int> SaveBinanceAsync(BinanceEntity binance);
        Task<int> DeleteBinanceAsync(BinanceEntity binance);
    }
}
