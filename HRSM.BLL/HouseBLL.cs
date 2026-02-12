using HRSM.DAL;
using HRSM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSM.BLL
{
    public class HouseBLL
    {
        private HouseDAL houseDAL = new HouseDAL();

        // ✅ 修改这里：增加 4 个可选参数
        public async Task<List<HouseInfo>> GetHouseListAsync(string name = "", string rentType = "", string direction = "", string layout = "")
        {
            // 将参数原封不动传给 DAL
            return await houseDAL.GetHouseListAsync(name, rentType, direction, layout);
        }
    }
}