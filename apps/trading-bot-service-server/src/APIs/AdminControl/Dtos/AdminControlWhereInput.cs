using TradingBotService.Core.Enums;

namespace TradingBotService.APIs.Dtos;

public class AdminControlWhereInput
{
    public ControlActionEnum? ControlAction { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public ScalingEventEnum? ScalingEvent { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
