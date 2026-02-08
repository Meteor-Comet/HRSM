using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class MenuInfo
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public int ParentId { get; set; }

    public string? MenuUrl { get; set; }

    public int Morder { get; set; }

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }
}
