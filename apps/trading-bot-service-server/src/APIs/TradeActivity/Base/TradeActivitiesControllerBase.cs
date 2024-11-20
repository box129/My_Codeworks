using Microsoft.AspNetCore.Mvc;
using TradingBotService.APIs;
using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;
using TradingBotService.APIs.Errors;

namespace TradingBotService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TradeActivitiesControllerBase : ControllerBase
{
    protected readonly ITradeActivitiesService _service;

    public TradeActivitiesControllerBase(ITradeActivitiesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TradeActivity
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TradeActivity>> CreateTradeActivity(
        TradeActivityCreateInput input
    )
    {
        var tradeActivity = await _service.CreateTradeActivity(input);

        return CreatedAtAction(nameof(TradeActivity), new { id = tradeActivity.Id }, tradeActivity);
    }

    /// <summary>
    /// Delete one TradeActivity
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTradeActivity(
        [FromRoute()] TradeActivityWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTradeActivity(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TradeActivities
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<TradeActivity>>> TradeActivities(
        [FromQuery()] TradeActivityFindManyArgs filter
    )
    {
        return Ok(await _service.TradeActivities(filter));
    }

    /// <summary>
    /// Meta data about TradeActivity records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TradeActivitiesMeta(
        [FromQuery()] TradeActivityFindManyArgs filter
    )
    {
        return Ok(await _service.TradeActivitiesMeta(filter));
    }

    /// <summary>
    /// Get one TradeActivity
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<TradeActivity>> TradeActivity(
        [FromRoute()] TradeActivityWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TradeActivity(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one TradeActivity
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTradeActivity(
        [FromRoute()] TradeActivityWhereUniqueInput uniqueId,
        [FromQuery()] TradeActivityUpdateInput tradeActivityUpdateDto
    )
    {
        try
        {
            await _service.UpdateTradeActivity(uniqueId, tradeActivityUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a User record for TradeActivity
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] TradeActivityWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
