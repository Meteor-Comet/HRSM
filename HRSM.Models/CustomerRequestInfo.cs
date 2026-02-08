using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class CustomerRequestInfo
{
    public int CustRequestId { get; set; }

    public int CustomerId { get; set; }

    public string RequestContent { get; set; } = null!;

    public string FollowUpUser { get; set; } = null!;

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }

    public string RequestState { get; set; } = null!;
}
