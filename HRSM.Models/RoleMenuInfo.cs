using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class RoleMenuInfo
{
    public int Rmid { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public int IsDeleted { get; set; }
}
