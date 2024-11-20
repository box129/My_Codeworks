using Microsoft.AspNetCore.Mvc;

namespace TradingBotService.APIs;

[ApiController()]
public class SubscriptionsController : SubscriptionsControllerBase
{
    public SubscriptionsController(ISubscriptionsService service)
        : base(service) { }
}
