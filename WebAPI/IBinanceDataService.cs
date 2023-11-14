namespace WebAPI
{
    public interface IBinanceDataService
    {
        Task<decimal> Get24hAvgPrice(string symbol);
    }
}
