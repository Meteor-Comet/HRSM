using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewHouseCountSatistic
{
    public int? TotalCount { get; set; }

    public int? PublishedCount { get; set; }

    public int? UnPublishedCount { get; set; }

    public int? TrentCount { get; set; }

    public int? HasRentCount { get; set; }

    public int? UnRentCount { get; set; }

    public int? TsaleCount { get; set; }

    public int? HasSaleCount { get; set; }

    public int? UnSaleCount { get; set; }
}
