using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingBotService.APIs;
using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;
using TradingBotService.APIs.Errors;

namespace TradingBotService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteUser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<User>>> Users([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<User>> User([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.User(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(uniqueId, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Subscriptions records to User
    /// </summary>
    [HttpPost("{Id}/subscriptions")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectSubscriptions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.ConnectSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Subscriptions records from User
    /// </summary>
    [HttpDelete("{Id}/subscriptions")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectSubscriptions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.DisconnectSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Subscriptions records for User
    /// </summary>
    [HttpGet("{Id}/subscriptions")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Subscription>>> FindSubscriptions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] SubscriptionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSubscriptions(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Subscriptions records for User
    /// </summary>
    [HttpPatch("{Id}/subscriptions")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateSubscriptions(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.UpdateSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple TradeActivities records to User
    /// </summary>
    [HttpPost("{Id}/tradeActivities")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectTradeActivities(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] TradeActivityWhereUniqueInput[] tradeActivitiesId
    )
    {
        try
        {
            await _service.ConnectTradeActivities(uniqueId, tradeActivitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple TradeActivities records from User
    /// </summary>
    [HttpDelete("{Id}/tradeActivities")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectTradeActivities(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] TradeActivityWhereUniqueInput[] tradeActivitiesId
    )
    {
        try
        {
            await _service.DisconnectTradeActivities(uniqueId, tradeActivitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple TradeActivities records for User
    /// </summary>
    [HttpGet("{Id}/tradeActivities")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<TradeActivity>>> FindTradeActivities(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] TradeActivityFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTradeActivities(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple TradeActivities records for User
    /// </summary>
    [HttpPatch("{Id}/tradeActivities")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTradeActivities(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] TradeActivityWhereUniqueInput[] tradeActivitiesId
    )
    {
        try
        {
            await _service.UpdateTradeActivities(uniqueId, tradeActivitiesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
