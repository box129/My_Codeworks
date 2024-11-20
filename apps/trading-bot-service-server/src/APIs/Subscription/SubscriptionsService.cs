using TradingBotService.Infrastructure;

namespace TradingBotService.APIs;

public class SubscriptionsService : SubscriptionsServiceBase
{
    public SubscriptionsService(TradingBotServiceDbContext context)
        : base(context) { }
}
