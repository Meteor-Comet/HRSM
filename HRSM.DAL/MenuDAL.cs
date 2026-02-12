using HRSM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class MenuDAL
    {
        /// <summary>
        /// 获取所有菜单（暂时获取全部，后续可改为根据用户权限获取）
        /// </summary>
        public async Task<List<MenuInfo>> GetAllMenusAsync()
        {
            using (HrsmContext db = new HrsmContext())
            {
                // 获取所有未删除的菜单
                return await db.MenuInfos.Where(m => m.IsDeleted == 0).ToListAsync();
            }
        }
    }
}