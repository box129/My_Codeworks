using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradingBotService.Core.Enums;

namespace TradingBotService.Infrastructure.Models;

[Table("TradeActivities")]
public class TradeActivityDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? SymbolField { get; set; }

    public DateTime? Timestamp { get; set; }

    [StringLength(1000)]
    public string? TradeId { get; set; }

    public TradeTypeEnum? TradeType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
