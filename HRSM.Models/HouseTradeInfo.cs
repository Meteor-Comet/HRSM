using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class HouseTradeInfo
{
    public int TradeId { get; set; }

    public int HouseId { get; set; }

    public int OwnerId { get; set; }

    public int CustomerId { get; set; }

    public string RentSale { get; set; } = null!;

    public decimal TradeAmount { get; set; }

    public string? PriceUnit { get; set; }

    public DateTime TradeTime { get; set; }

    public string TradeWay { get; set; } = null!;

    public string DealUser { get; set; } = null!;

    public int IsDeleted { get; set; }
}
