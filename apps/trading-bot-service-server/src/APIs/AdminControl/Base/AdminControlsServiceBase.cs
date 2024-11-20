using Microsoft.EntityFrameworkCore;
using TradingBotService.APIs;
using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;
using TradingBotService.APIs.Errors;
using TradingBotService.APIs.Extensions;
using TradingBotService.Infrastructure;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs;

public abstract class AdminControlsServiceBase : IAdminControlsService
{
    protected readonly TradingBotServiceDbContext _context;

    public AdminControlsServiceBase(TradingBotServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one AdminControl
    /// </summary>
    public async Task<AdminControl> CreateAdminControl(AdminControlCreateInput createDto)
    {
        var adminControl = new AdminControlDbModel
        {
            ControlAction = createDto.ControlAction,
            CreatedAt = createDto.CreatedAt,
            ScalingEvent = createDto.ScalingEvent,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            adminControl.Id = createDto.Id;
        }

        _context.AdminControls.Add(adminControl);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AdminControlDbModel>(adminControl.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one AdminControl
    /// </summary>
    public async Task DeleteAdminControl(AdminControlWhereUniqueInput uniqueId)
    {
        var adminControl = await _context.AdminControls.FindAsync(uniqueId.Id);
        if (adminControl == null)
        {
            throw new NotFoundException();
        }

        _context.AdminControls.Remove(adminControl);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AdminControls
    /// </summary>
    public async Task<List<AdminControl>> AdminControls(AdminControlFindManyArgs findManyArgs)
    {
        var adminControls = await _context
            .AdminControls.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return adminControls.ConvertAll(adminControl => adminControl.ToDto());
    }

    /// <summary>
    /// Meta data about AdminControl records
    /// </summary>
    public async Task<MetadataDto> AdminControlsMeta(AdminControlFindManyArgs findManyArgs)
    {
        var count = await _context.AdminControls.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one AdminControl
    /// </summary>
    public async Task<AdminControl> AdminControl(AdminControlWhereUniqueInput uniqueId)
    {
        var adminControls = await this.AdminControls(
            new AdminControlFindManyArgs { Where = new AdminControlWhereInput { Id = uniqueId.Id } }
        );
        var adminControl = adminControls.FirstOrDefault();
        if (adminControl == null)
        {
            throw new NotFoundException();
        }

        return adminControl;
    }

    /// <summary>
    /// Update one AdminControl
    /// </summary>
    public async Task UpdateAdminControl(
        AdminControlWhereUniqueInput uniqueId,
        AdminControlUpdateInput updateDto
    )
    {
        var adminControl = updateDto.ToModel(uniqueId);

        _context.Entry(adminControl).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AdminControls.Any(e => e.Id == adminControl.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
