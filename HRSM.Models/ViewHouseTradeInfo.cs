using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewHouseTradeInfo
{
    public int TradeId { get; set; }

    public int HouseId { get; set; }

    public string HouseName { get; set; } = null!;

    public string? Building { get; set; }

    public string? HouseAddress { get; set; }

    public decimal? HousePrice { get; set; }

    public string? PriceUnit { get; set; }

    public string? HouseDirection { get; set; }

    public string? HouseLayout { get; set; }

    public int OwnerId { get; set; }

    public string OwnerName { get; set; } = null!;

    public string? OwnerPhone { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string? CustomerAddress { get; set; }

    public string RentSale { get; set; } = null!;

    public decimal TradeAmount { get; set; }

    public DateTime TradeTime { get; set; }

    public string TradeWay { get; set; } = null!;

    public string DealUser { get; set; } = null!;

    public int IsDeleted { get; set; }

    public int HouseFloor { get; set; }

    public decimal HouseArea { get; set; }
}
