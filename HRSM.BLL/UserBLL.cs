using HRSM.DAL;
using HRSM.Models;

namespace HRSM.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        /// <summary>
        /// 处理登录逻辑
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="msg">返回给界面的提示信息（如：密码错误）</param>
        /// <returns>登录成功返回 true，失败返回 false</returns>
        public bool Login(string userName, string userPwd, out string msg)
        {
            msg = "";

            // 1. 检查数据库里有没有这个人
            UserInfo? user = userDAL.GetUserInfo(userName);

            if (user == null)
            {
                msg = "用户名不存在！";
                return false;
            }

            // 2. 检查密码 (你的数据库目前是明文存储，所以直接对比)
            if (user.UserPwd != userPwd)
            {
                msg = "密码错误！";
                return false;
            }

            // 3. 检查账号状态 (UserState: true为正常，false为冻结)
            if (user.UserState == false)
            {
                msg = "该账号已被冻结，请联系管理员！";
                return false;
            }

            // 登录成功
            msg = "登录成功";
            return true;
        }
    }
}