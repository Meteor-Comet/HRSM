using HRSM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq; // 必须引用
using System.Threading.Tasks;

namespace HRSM.DAL
{
    public class HouseDAL
    {
        // 获取所有房屋列表 (带业主姓名)
        public async Task<List<HouseInfo>> GetHouseListAsync(string name, string rentType, string direction, string layout)
        {
            using (HrsmContext db = new HrsmContext())
            {
                // 1. 基本查询逻辑
                var query = from h in db.HouseInfos
                            join o in db.HouseOwnerInfos on h.OwnerId equals o.OwnerId
                            where h.IsDeleted == 0
                            select new { House = h, OwnerName = o.OwnerName };

                // 2. 动态组合条件 (不为空才增加条件)
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(q => q.House.HouseName.Contains(name));

                if (!string.IsNullOrEmpty(rentType) && rentType != "全部")
                    query = query.Where(q => q.House.RentSale == rentType);

                if (!string.IsNullOrEmpty(direction) && direction != "全部")
                    query = query.Where(q => q.House.HouseDirection == direction);

                if (!string.IsNullOrEmpty(layout))
                    query = query.Where(q => q.House.HouseLayout.Contains(layout));

                var rawList = await query.ToListAsync();

                // 3. 内存组装
                return rawList.Select(item => {
                    item.House.OwnerName = item.OwnerName;
                    return item.House;
                }).ToList();
            }
        }
    }
}