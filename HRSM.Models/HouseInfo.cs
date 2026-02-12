using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSM.Models;

public partial class HouseInfo
{
    public int HouseId { get; set; }

    public string HouseName { get; set; } = null!;

    public string? Building { get; set; }

    public string? HouseAddress { get; set; }

    public string RentSale { get; set; } = null!;

    public decimal? HousePrice { get; set; }

    public string? PriceUnit { get; set; }

    public string? HouseDirection { get; set; }

    public string? HouseLayout { get; set; }

    public int? OwnerId { get; set; }

    public int HouseFloor { get; set; }

    public decimal HouseArea { get; set; }

    public string HouseState { get; set; } = null!;

    public string? Remark { get; set; }

    public string? HousePic { get; set; }

    public bool IsPublish { get; set; }

    public DateTime? PublishTime { get; set; }

    public int IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }

    public string? PublishUser { get; set; }

    [NotMapped]
    public string OwnerName { get; set; }
}
