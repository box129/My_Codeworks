using TradingBotService.Core.Enums;

namespace TradingBotService.APIs.Dtos;

public class SubscriptionCreateInput
{
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Id { get; set; }

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
