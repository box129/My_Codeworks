using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;

namespace TradingBotService.APIs;

public interface ITradeActivitiesService
{
    /// <summary>
    /// Create one TradeActivity
    /// </summary>
    public Task<TradeActivity> CreateTradeActivity(TradeActivityCreateInput tradeactivity);

    /// <summary>
    /// Delete one TradeActivity
    /// </summary>
    public Task DeleteTradeActivity(TradeActivityWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TradeActivities
    /// </summary>
    public Task<List<TradeActivity>> TradeActivities(TradeActivityFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about TradeActivity records
    /// </summary>
    public Task<MetadataDto> TradeActivitiesMeta(TradeActivityFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TradeActivity
    /// </summary>
    public Task<TradeActivity> TradeActivity(TradeActivityWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one TradeActivity
    /// </summary>
    public Task UpdateTradeActivity(
        TradeActivityWhereUniqueInput uniqueId,
        TradeActivityUpdateInput updateDto
    );

    /// <summary>
    /// Get a User record for TradeActivity
    /// </summary>
    public Task<User> GetUser(TradeActivityWhereUniqueInput uniqueId);
}
