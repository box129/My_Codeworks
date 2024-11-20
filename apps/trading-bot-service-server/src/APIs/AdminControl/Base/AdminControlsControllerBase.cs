using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingBotService.APIs;
using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;
using TradingBotService.APIs.Errors;

namespace TradingBotService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AdminControlsControllerBase : ControllerBase
{
    protected readonly IAdminControlsService _service;

    public AdminControlsControllerBase(IAdminControlsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one AdminControl
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<AdminControl>> CreateAdminControl(AdminControlCreateInput input)
    {
        var adminControl = await _service.CreateAdminControl(input);

        return CreatedAtAction(nameof(AdminControl), new { id = adminControl.Id }, adminControl);
    }

    /// <summary>
    /// Delete one AdminControl
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteAdminControl(
        [FromRoute()] AdminControlWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAdminControl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AdminControls
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<AdminControl>>> AdminControls(
        [FromQuery()] AdminControlFindManyArgs filter
    )
    {
        return Ok(await _service.AdminControls(filter));
    }

    /// <summary>
    /// Meta data about AdminControl records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AdminControlsMeta(
        [FromQuery()] AdminControlFindManyArgs filter
    )
    {
        return Ok(await _service.AdminControlsMeta(filter));
    }

    /// <summary>
    /// Get one AdminControl
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<AdminControl>> AdminControl(
        [FromRoute()] AdminControlWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AdminControl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one AdminControl
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateAdminControl(
        [FromRoute()] AdminControlWhereUniqueInput uniqueId,
        [FromQuery()] AdminControlUpdateInput adminControlUpdateDto
    )
    {
        try
        {
            await _service.UpdateAdminControl(uniqueId, adminControlUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
