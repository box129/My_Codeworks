using Microsoft.EntityFrameworkCore;
using TradingBotService.APIs;
using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;
using TradingBotService.APIs.Errors;
using TradingBotService.APIs.Extensions;
using TradingBotService.Infrastructure;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs;

public abstract class TradeActivitiesServiceBase : ITradeActivitiesService
{
    protected readonly TradingBotServiceDbContext _context;

    public TradeActivitiesServiceBase(TradingBotServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TradeActivity
    /// </summary>
    public async Task<TradeActivity> CreateTradeActivity(TradeActivityCreateInput createDto)
    {
        var tradeActivity = new TradeActivityDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            SymbolField = createDto.SymbolField,
            Timestamp = createDto.Timestamp,
            TradeId = createDto.TradeId,
            TradeType = createDto.TradeType,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            tradeActivity.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            tradeActivity.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.TradeActivities.Add(tradeActivity);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TradeActivityDbModel>(tradeActivity.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TradeActivity
    /// </summary>
    public async Task DeleteTradeActivity(TradeActivityWhereUniqueInput uniqueId)
    {
        var tradeActivity = await _context.TradeActivities.FindAsync(uniqueId.Id);
        if (tradeActivity == null)
        {
            throw new NotFoundException();
        }

        _context.TradeActivities.Remove(tradeActivity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TradeActivities
    /// </summary>
    public async Task<List<TradeActivity>> TradeActivities(TradeActivityFindManyArgs findManyArgs)
    {
        var tradeActivities = await _context
            .TradeActivities.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return tradeActivities.ConvertAll(tradeActivity => tradeActivity.ToDto());
    }

    /// <summary>
    /// Meta data about TradeActivity records
    /// </summary>
    public async Task<MetadataDto> TradeActivitiesMeta(TradeActivityFindManyArgs findManyArgs)
    {
        var count = await _context.TradeActivities.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one TradeActivity
    /// </summary>
    public async Task<TradeActivity> TradeActivity(TradeActivityWhereUniqueInput uniqueId)
    {
        var tradeActivities = await this.TradeActivities(
            new TradeActivityFindManyArgs
            {
                Where = new TradeActivityWhereInput { Id = uniqueId.Id }
            }
        );
        var tradeActivity = tradeActivities.FirstOrDefault();
        if (tradeActivity == null)
        {
            throw new NotFoundException();
        }

        return tradeActivity;
    }

    /// <summary>
    /// Update one TradeActivity
    /// </summary>
    public async Task UpdateTradeActivity(
        TradeActivityWhereUniqueInput uniqueId,
        TradeActivityUpdateInput updateDto
    )
    {
        var tradeActivity = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            tradeActivity.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(tradeActivity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TradeActivities.Any(e => e.Id == tradeActivity.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a User record for TradeActivity
    /// </summary>
    public async Task<User> GetUser(TradeActivityWhereUniqueInput uniqueId)
    {
        var tradeActivity = await _context
            .TradeActivities.Where(tradeActivity => tradeActivity.Id == uniqueId.Id)
            .Include(tradeActivity => tradeActivity.User)
            .FirstOrDefaultAsync();
        if (tradeActivity == null)
        {
            throw new NotFoundException();
        }
        return tradeActivity.User.ToDto();
    }
}
