using HRSM.BLL;
using HRSM.HRSMApp.Utils;
using HRSM.Models;
using HRSM.HRSMApp.Views; // ✅ 必须加这一行！否则找不到 HouseDetailView
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSM.HRSMApp.ViewModels
{
    public class HouseListViewModel : ViewModelBase
    {
        private HouseBLL houseBLL = new HouseBLL();

        public HouseListViewModel()
        {
            // 初始化查询命令
            SearchCommand = new RelayCommand(p => LoadData());

            // ✅ 1. 初始化详情跳转命令
            ShowDetailCommand = new RelayCommand(DoShowDetail);

            LoadData();
        }

        #region 搜索属性 (保持不变)
        private string _searchName;
        public string SearchName { get => _searchName; set { _searchName = value; OnPropertyChanged(); } }

        private string _searchRentType = "全部";
        public string SearchRentType { get => _searchRentType; set { _searchRentType = value; OnPropertyChanged(); } }

        private string _searchDirection = "全部";
        public string SearchDirection { get => _searchDirection; set { _searchDirection = value; OnPropertyChanged(); } }

        private string _searchLayout;
        public string SearchLayout { get => _searchLayout; set { _searchLayout = value; OnPropertyChanged(); } }

        public List<string> RentTypes { get; set; } = new List<string> { "全部", "租", "售" };
        public List<string> Directions { get; set; } = new List<string> { "全部", "南北", "东西", "东南", "西南" };
        #endregion

        public ObservableCollection<HouseInfo> HouseList { get; set; } = new ObservableCollection<HouseInfo>();

        // 命令
        public RelayCommand SearchCommand { get; set; }

        // ✅ 2. 定义详情跳转命令属性
        public RelayCommand ShowDetailCommand { get; set; }


        // ✅ 3. 实现跳转逻辑方法
        private void DoShowDetail(object obj)
        {
            // obj 就是界面上传过来的那个 HouseInfo 对象（被点击的那套房）
            HouseInfo selectedHouse = obj as HouseInfo;

            if (selectedHouse == null) return;

            // 创建详情窗口 (View)
            var detailWin = new HouseDetailView();

            // 创建详情 ViewModel，并把选中的房子传给它
            detailWin.DataContext = new HouseDetailViewModel(selectedHouse);

            // 打开窗口 (ShowDialog 表示必须关掉这个窗口才能点别的)
            detailWin.ShowDialog();
        }

        private async void LoadData()
        {
            var list = await houseBLL.GetHouseListAsync(SearchName, SearchRentType, SearchDirection, SearchLayout);
            HouseList.Clear();
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.HousePic))
                {
                    item.HousePic = "/imgs/house/default_house.png";
                }
                HouseList.Add(item);
            }
        }
    }
}