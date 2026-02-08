using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class RoleInfo
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string? Remark { get; set; }

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }
}
