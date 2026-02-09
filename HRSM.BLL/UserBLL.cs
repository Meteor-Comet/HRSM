using HRSM.DAL;
using HRSM.Models;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        // 返回值变成了 Task<(bool, string)>，括号里是元组
        public async Task<(bool IsSuccess, string Msg)> LoginAsync(string userName, string userPwd)
        {
            // 1. 异步调用 DAL
            UserInfo? user = await userDAL.GetUserInfoAsync(userName);

            if (user == null)
            {
                return (false, "用户名不存在！");
            }

            if (user.UserPwd != userPwd)
            {
                return (false, "密码错误！");
            }

            if (user.UserState == false)
            {
                return (false, "该账号已被冻结，请联系管理员！");
            }

            if (user.IsDeleted == 1)
            {
                return (false, "该账号已失效！");
            }

            return (true, "登录成功，欢迎回来！");
        }
    }
}