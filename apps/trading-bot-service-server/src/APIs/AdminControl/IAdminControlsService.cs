using TradingBotService.APIs.Common;
using TradingBotService.APIs.Dtos;

namespace TradingBotService.APIs;

public interface IAdminControlsService
{
    /// <summary>
    /// Create one AdminControl
    /// </summary>
    public Task<AdminControl> CreateAdminControl(AdminControlCreateInput admincontrol);

    /// <summary>
    /// Delete one AdminControl
    /// </summary>
    public Task DeleteAdminControl(AdminControlWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AdminControls
    /// </summary>
    public Task<List<AdminControl>> AdminControls(AdminControlFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about AdminControl records
    /// </summary>
    public Task<MetadataDto> AdminControlsMeta(AdminControlFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AdminControl
    /// </summary>
    public Task<AdminControl> AdminControl(AdminControlWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AdminControl
    /// </summary>
    public Task UpdateAdminControl(
        AdminControlWhereUniqueInput uniqueId,
        AdminControlUpdateInput updateDto
    );
}
