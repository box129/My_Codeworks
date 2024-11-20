using TradingBotService.Infrastructure;

namespace TradingBotService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(TradingBotServiceDbContext context)
        : base(context) { }
}
