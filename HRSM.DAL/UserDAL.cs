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
    }
}