using HRSM.Models;
using System.Linq;

namespace HRSM.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 根据用户名查找用户信息
        /// </summary>
        /// <param name="userName">登录账号</param>
        /// <returns>找到的用户实体，如果没有则返回 null</returns>
        public UserInfo? GetUserInfo(string userName)
        {
            using (HrsmContext db = new HrsmContext())
            {
                return db.UserInfos.FirstOrDefault(u => u.UserName == userName && u.IsDeleted == 0);
            }
        }
    }
}