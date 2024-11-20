using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradingBotService.Core.Enums;

namespace TradingBotService.Infrastructure.Models;

[Table("AdminControls")]
public class AdminControlDbModel
{
    public ControlActionEnum? ControlAction { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public ScalingEventEnum? ScalingEvent { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
