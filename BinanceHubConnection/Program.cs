using BinanceHubConnection.Models;
using Newtonsoft.Json;
using WebSocketSharp;

using (var ws = new WebSocket("wss://stream.binance.com:9443/stream?streams=btcusdt@depth/adausdt@depth/ethusdt@depth"))
{
    ws.OnMessage += async (sender, e) =>
    {
        var binanceEvent = JsonConvert.DeserializeObject<BinanceDataCombinedModel>(e.Data);

        var data = BuildModel(binanceEvent.Data);

        if (data != null)
        {
            //Start processing binace data 
            await BinanceProcessor.BinanceProcessor.Process(data);
        }
    };

    ws.Connect();
    Console.WriteLine("Press Enter to exit.");
    Console.ReadLine();
}

static BinanceProcessor.Models.BinanceDataModel BuildModel(BinanceDataModel model)
{
    if(model != null)
    {
        return new BinanceProcessor.Models.BinanceDataModel()
        {
            EventType = model.EventType,
            EventTime = model.EventTime,
            Symbol = model.Symbol,
            FirstUpdateIdInEvent = model.FirstUpdateIdInEvent,
            FinalUpdateIdInEvent = model.FinalUpdateIdInEvent,
            BidsToBeUpdated = model.BidsToBeUpdated,
            AsksToBeUpdated = model.AsksToBeUpdated,
        };
    }

    return null;
}


