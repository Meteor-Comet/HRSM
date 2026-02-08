using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class HouseStateInfo
{
    public int StateId { get; set; }

    public string StateName { get; set; } = null!;

    public int Rsid { get; set; }
}
