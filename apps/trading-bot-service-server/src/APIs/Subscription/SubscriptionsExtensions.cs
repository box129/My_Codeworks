using TradingBotService.APIs.Dtos;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs.Extensions;

public static class SubscriptionsExtensions
{
    public static Subscription ToDto(this SubscriptionDbModel model)
    {
        return new Subscription
        {
            CreatedAt = model.CreatedAt,
            EndDate = model.EndDate,
            Id = model.Id,
            StartDate = model.StartDate,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static SubscriptionDbModel ToModel(
        this SubscriptionUpdateInput updateDto,
        SubscriptionWhereUniqueInput uniqueId
    )
    {
        var subscription = new SubscriptionDbModel
        {
            Id = uniqueId.Id,
            EndDate = updateDto.EndDate,
            StartDate = updateDto.StartDate,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            subscription.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            subscription.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            subscription.UserId = updateDto.User;
        }

        return subscription;
    }
}
