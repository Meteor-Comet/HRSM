using HRSM.Models;
using Microsoft.EntityFrameworkCore; // 必须引用这个！否则没有 FirstOrDefaultAsync
using System.Threading.Tasks;       // 必须引用这个！为了使用 Task

namespace HRSM.DAL
{
    public class UserDAL
    {
        // 注意：返回值变成了 Task<UserInfo?>，方法名加了 Async 后缀
        public async Task<UserInfo?> GetUserInfoAsync(string userName)
        {
            using (HrsmContext db = new HrsmContext())
            {
                // 使用 FirstOrDefaultAsync 进行异步查询
                return await db.UserInfos.FirstOrDefaultAsync(u => u.UserName == userName && u.IsDeleted == 0);
            }
        }

        /// <summary>
        /// 根据用户ID获取角色名称
        /// </summary>
        public string GetUserRoleName(int userId)
        {
            using (HrsmContext db = new HrsmContext())
            {
                // 联表查询：UserRoleInfos -> RoleInfos
                var roleName = (from ur in db.UserRoleInfos
                                join r in db.RoleInfos on ur.RoleId equals r.RoleId
                                where ur.UserId == userId && ur.IsDeleted == 0
                                select r.RoleName).FirstOrDefault();

                return roleName ?? "普通用户"; // 如果没查到，默认显示普通用户
            }
        }

    }
}