using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;

namespace TradingBotService.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Subscriptions records to User
    /// </summary>
    public Task ConnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Disconnect multiple Subscriptions records from User
    /// </summary>
    public Task DisconnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Find multiple Subscriptions records for User
    /// </summary>
    public Task<List<Subscription>> FindSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionFindManyArgs SubscriptionFindManyArgs
    );

    /// <summary>
    /// Update multiple Subscriptions records for User
    /// </summary>
    public Task UpdateSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Connect multiple TradeActivities records to User
    /// </summary>
    public Task ConnectTradeActivities(
        UserWhereUniqueInput uniqueId,
        TradeActivityWhereUniqueInput[] tradeActivitiesId
    );

    /// <summary>
    /// Disconnect multiple TradeActivities records from User
    /// </summary>
    public Task DisconnectTradeActivities(
        UserWhereUniqueInput uniqueId,
        TradeActivityWhereUniqueInput[] tradeActivitiesId
    );

    /// <summary>
    /// Find multiple TradeActivities records for User
    /// </summary>
    public Task<List<TradeActivity>> FindTradeActivities(
        UserWhereUniqueInput uniqueId,
        TradeActivityFindManyArgs TradeActivityFindManyArgs
    );

    /// <summary>
    /// Update multiple TradeActivities records for User
    /// </summary>
    public Task UpdateTradeActivities(
        UserWhereUniqueInput uniqueId,
        TradeActivityWhereUniqueInput[] tradeActivitiesId
    );
}
