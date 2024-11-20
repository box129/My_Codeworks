using Microsoft.AspNetCore.Mvc;

namespace TradingBotService.APIs;

[ApiController()]
public class TradeActivitiesController : TradeActivitiesControllerBase
{
    public TradeActivitiesController(ITradeActivitiesService service)
        : base(service) { }
}
