using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

    [NotMapped]
    public List<MenuInfo> SubMenus { get; set; } = new List<MenuInfo>();
}
