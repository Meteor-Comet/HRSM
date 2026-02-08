using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class HouseOwnerInfo
{
    public int OwnerId { get; set; }

    public string OwnerName { get; set; } = null!;

    public string OwnerType { get; set; } = null!;

    public string? Contactor { get; set; }

    public string? OwnerPhone { get; set; }

    public string? OwnerAddress { get; set; }

    public string? Remark { get; set; }

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }
}
