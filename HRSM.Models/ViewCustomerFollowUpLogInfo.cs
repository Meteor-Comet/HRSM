using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewCustomerFollowUpLogInfo
{
    public int FlogId { get; set; }

    public int CustRequestId { get; set; }

    public DateTime FollowUpTime { get; set; }

    public string FollowUpContent { get; set; } = null!;

    public string FollowUpUser { get; set; } = null!;

    public string FollowUpState { get; set; } = null!;

    public int IsDeleted { get; set; }

    public string RequestContent { get; set; } = null!;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;
}
