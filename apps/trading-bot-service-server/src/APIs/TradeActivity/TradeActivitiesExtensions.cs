using TradingBotService.APIs.Dtos;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs.Extensions;

public static class TradeActivitiesExtensions
{
    public static TradeActivity ToDto(this TradeActivityDbModel model)
    {
        return new TradeActivity
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            SymbolField = model.SymbolField,
            Timestamp = model.Timestamp,
            TradeId = model.TradeId,
            TradeType = model.TradeType,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static TradeActivityDbModel ToModel(
        this TradeActivityUpdateInput updateDto,
        TradeActivityWhereUniqueInput uniqueId
    )
    {
        var tradeActivity = new TradeActivityDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            SymbolField = updateDto.SymbolField,
            Timestamp = updateDto.Timestamp,
            TradeId = updateDto.TradeId,
            TradeType = updateDto.TradeType
        };

        if (updateDto.CreatedAt != null)
        {
            tradeActivity.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            tradeActivity.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            tradeActivity.UserId = updateDto.User;
        }

        return tradeActivity;
    }
}
