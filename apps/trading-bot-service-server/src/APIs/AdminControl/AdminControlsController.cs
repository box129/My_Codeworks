using Microsoft.AspNetCore.Mvc;

namespace TradingBotService.APIs;

[ApiController()]
public class AdminControlsController : AdminControlsControllerBase
{
    public AdminControlsController(IAdminControlsService service)
        : base(service) { }
}
