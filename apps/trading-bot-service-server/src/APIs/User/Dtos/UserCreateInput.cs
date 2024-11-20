using TradingBotService.Core.Enums;

namespace TradingBotService.APIs.Dtos;

public class UserCreateInput
{
    public string? ApiKey { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public StatusEnum? Status { get; set; }

    public List<Subscription>? Subscriptions { get; set; }

    public List<TradeActivity>? TradeActivities { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }
}
