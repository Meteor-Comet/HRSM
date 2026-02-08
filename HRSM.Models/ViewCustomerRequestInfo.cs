using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewCustomerRequestInfo
{
    public int CustRequestId { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public string RequestContent { get; set; } = null!;

    public string FollowUpUser { get; set; } = null!;

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }

    public string CustomerState { get; set; } = null!;

    public string RequestState { get; set; } = null!;
}
