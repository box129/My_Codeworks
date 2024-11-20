using TradingBotService.APIs.Dtos;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs.Extensions;

public static class AdminControlsExtensions
{
    public static AdminControl ToDto(this AdminControlDbModel model)
    {
        return new AdminControl
        {
            ControlAction = model.ControlAction,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            ScalingEvent = model.ScalingEvent,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AdminControlDbModel ToModel(
        this AdminControlUpdateInput updateDto,
        AdminControlWhereUniqueInput uniqueId
    )
    {
        var adminControl = new AdminControlDbModel
        {
            Id = uniqueId.Id,
            ControlAction = updateDto.ControlAction,
            ScalingEvent = updateDto.ScalingEvent
        };

        if (updateDto.CreatedAt != null)
        {
            adminControl.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            adminControl.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return adminControl;
    }
}
