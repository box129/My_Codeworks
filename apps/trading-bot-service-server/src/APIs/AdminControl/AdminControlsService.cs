using TradingBotService.Infrastructure;

namespace TradingBotService.APIs;

public class AdminControlsService : AdminControlsServiceBase
{
    public AdminControlsService(TradingBotServiceDbContext context)
        : base(context) { }
}
