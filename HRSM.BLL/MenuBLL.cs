using HRSM.DAL;
using HRSM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class MenuBLL
    {
        private MenuDAL menuDAL = new MenuDAL();

        public async Task<List<MenuInfo>> GetMenusTreeAsync()
        {
            // 1. 获取所有菜单数据
            List<MenuInfo> allMenus = await menuDAL.GetAllMenusAsync();

            // 2. 筛选出顶级菜单 (ParentId = 0)
            List<MenuInfo> topMenus = allMenus.Where(m => m.ParentId == 0).OrderBy(m => m.Morder).ToList();

            // 3. 递归或循环填入子菜单
            foreach (var top in topMenus)
            {
                // 找当前菜单的子菜单
                top.SubMenus = allMenus.Where(m => m.ParentId == top.MenuId)
                                       .OrderBy(m => m.Morder)
                                       .ToList();
            }

            return topMenus;
        }
    }
}