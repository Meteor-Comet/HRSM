using HRSM.Models;

namespace HRSM.HRSMApp.ViewModels
{
    public class HouseDetailViewModel : ViewModelBase
    {
        public HouseDetailViewModel(HouseInfo house)
        {
            this.House = house;
        }

        // 存储当前显示的房屋对象
        public HouseInfo House { get; set; }
    }
}