using System;
using System.Collections.Generic;

namespace HRSM.Models;

public partial class ViewUserRoleInfo
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public bool UserState { get; set; }

    public string? UserFname { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public int UserDeleted { get; set; }

    public string? UserPhone { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPwd { get; set; } = null!;
}
