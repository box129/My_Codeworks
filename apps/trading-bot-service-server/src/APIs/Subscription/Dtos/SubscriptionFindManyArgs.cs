using Microsoft.AspNetCore.Mvc;
using TradingBotService.APIs.Common;
using TradingBotService.Infrastructure.Models;

namespace TradingBotService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class SubscriptionFindManyArgs : FindManyInput<Subscription, SubscriptionWhereInput> { }
