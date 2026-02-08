using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class CustomerInfo
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public string? Contactor { get; set; }

    public string CustomerPhone { get; set; } = null!;

    public string? CustomerAddress { get; set; }

    public string? Remark { get; set; }

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }

    public string CustomerState { get; set; } = null!;
}
