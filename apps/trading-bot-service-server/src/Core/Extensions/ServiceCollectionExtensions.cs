using TradingBotService.APIs;

namespace TradingBotService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAdminControlsService, AdminControlsService>();
        services.AddScoped<ISubscriptionsService, SubscriptionsService>();
        services.AddScoped<ITradeActivitiesService, TradeActivitiesService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
