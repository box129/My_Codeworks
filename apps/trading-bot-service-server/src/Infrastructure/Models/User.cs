using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradingBotService.Core.Enums;

namespace TradingBotService.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [StringLength(1000)]
    public string? ApiKey { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    [Required()]
    public string Roles { get; set; }

    public StatusEnum? Status { get; set; }

    public List<SubscriptionDbModel>? Subscriptions { get; set; } = new List<SubscriptionDbModel>();

    public List<TradeActivityDbModel>? TradeActivities { get; set; } =
        new List<TradeActivityDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }
}
