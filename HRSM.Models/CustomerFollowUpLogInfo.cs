using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class CustomerFollowUpLogInfo
{
    public int FlogId { get; set; }

    public int CustRequestId { get; set; }

    public DateTime FollowUpTime { get; set; }

    public string FollowUpContent { get; set; } = null!;

    public string FollowUpUser { get; set; } = null!;

    public int IsDeleted { get; set; }

    public string FollowUpState { get; set; } = null!;
}
