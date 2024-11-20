using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.Infrastructure;

public class TradingBotServiceDbContext : IdentityDbContext<IdentityUser>
{
    public TradingBotServiceDbContext(DbContextOptions<TradingBotServiceDbContext> options)
        : base(options) { }

    public DbSet<SubscriptionDbModel> Subscriptions { get; set; }

    public DbSet<AdminControlDbModel> AdminControls { get; set; }

    public DbSet<TradeActivityDbModel> TradeActivities { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
