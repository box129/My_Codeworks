using TradingBotService.Infrastructure;

namespace TradingBotService.APIs;

public class TradeActivitiesService : TradeActivitiesServiceBase
{
    public TradeActivitiesService(TradingBotServiceDbContext context)
        : base(context) { }
}
