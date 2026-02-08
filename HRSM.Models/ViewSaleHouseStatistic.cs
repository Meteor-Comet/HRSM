using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewSaleHouseStatistic
{
    public string DealUser { get; set; } = null!;

    public string? UserFname { get; set; }

    public int? TotalCount { get; set; }

    public int? RentCount { get; set; }

    public int? SaleCount { get; set; }
}
