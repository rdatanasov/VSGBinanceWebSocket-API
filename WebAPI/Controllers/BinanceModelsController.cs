using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class BinanceModelsController : ControllerBase
    {
        public IBinanceDataService BinanceDataService { get; set; }
        public BinanceModelsController(IBinanceDataService _binanceDataService)
        {
            BinanceDataService = _binanceDataService;
        }

        [HttpGet("{symbol}/24hAvgPrice")]
        public async Task<ActionResult<IEnumerable<BinanceModel>>> GetBinancesAsync(string symbol)
        {
            var result = await BinanceDataService.Get24hAvgPrice(symbol);

            return Ok(result);
        }
    }
}
