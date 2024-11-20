using TradingBotService.Core.Enums;

namespace TradingBotService.APIs.Dtos;

public class TradeActivity
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? SymbolField { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? TradeId { get; set; }

    public TradeTypeEnum? TradeType { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
