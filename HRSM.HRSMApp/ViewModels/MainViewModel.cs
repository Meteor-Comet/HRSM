using HRSM.BLL;
using HRSM.HRSMApp.Utils;
using HRSM.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using HRSM.HRSMApp.Views;

namespace HRSM.HRSMApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        MenuBLL menuBLL = new MenuBLL();
        UserBLL userBLL = new UserBLL();

        public MainViewModel()
        {
            // 1. 初始化为游客状态
            SetGuestMode();

            // 2. 启动时钟
            StartClock();

            // 3. 加载菜单
            LoadMenus();

            // 4. 初始化命令
            OpenMenuCommand = new RelayCommand(DoOpenMenu);
            CloseTabCommand = new RelayCommand(DoCloseTab);
            LoginCommand = new RelayCommand(DoLogin); // ✅ 新增登录命令
            ExitCommand = new RelayCommand(DoExit);   // 退出/注销命令

            // 5. 默认打开“房屋列表信息”页面 (假设 MenuId 或 MenuName 已知)
            // 这里我们用一个小技巧：加载完菜单后，自动触发一次打开页面
            // (实际开发中建议根据 MenuName 查找)
            // OpenDefaultPage(); // 稍后在 LoadMenus 里调用
        }

        #region 属性

        // 当前用户
        private UserInfo _currentUser;
        public UserInfo CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
                // 用户变化时，更新 IsLoggedIn 属性，控制按钮显示
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        // 角色名
        private string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; OnPropertyChanged(); }
        }

        // 辅助属性：是否已登录 (用于界面控制显示 登录按钮 还是 退出按钮)
        public bool IsLoggedIn => CurrentUser != null && CurrentUser.UserName != "游客";

        // 时间
        private string _currentTimeStr;
        public string CurrentTimeStr
        {
            get { return _currentTimeStr; }
            set { _currentTimeStr = value; OnPropertyChanged(); }
        }

        // 集合
        public ObservableCollection<MenuInfo> MenuList { get; set; } = new ObservableCollection<MenuInfo>();
        public ObservableCollection<TabItem> TabItems { get; set; } = new ObservableCollection<TabItem>();

        private TabItem _selectedTab;
        public TabItem SelectedTab
        {
            get { return _selectedTab; }
            set { _selectedTab = value; OnPropertyChanged(); }
        }

        #endregion

        #region 命令

        public RelayCommand OpenMenuCommand { get; set; }
        public RelayCommand CloseTabCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }


        #endregion

        #region 方法

        private void SetGuestMode()
        {
            // 创建一个假的游客对象
            CurrentUser = new UserInfo { UserName = "游客", UserFname = "未登录" };
            RoleName = "访客";
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => CurrentTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();
        }

        private async void LoadMenus()
        {
            var menus = await menuBLL.GetMenusTreeAsync();
            MenuList.Clear();
            foreach (var m in menus)
            {
                MenuList.Add(m);
            }

            // ✅ 加载完菜单后，尝试自动打开“房屋列表信息”
            // 假设数据库里有个菜单叫 "房屋列表信息"
            var houseMenu = menus.SelectMany(m => m.SubMenus).FirstOrDefault(s => s.MenuName.Contains("房屋列表"));
            if (houseMenu != null)
            {
                DoOpenMenu(houseMenu);
            }
        }

        // ✅ 核心：弹出登录窗口
        private void DoLogin(object obj)
        {
            // 创建登录窗口
            LoginWindow loginWin = new LoginWindow();
            // 以对话框模式打开 (ShowDialog 会阻塞代码，直到窗口关闭)
            bool? result = loginWin.ShowDialog();

            // 如果 DialogResult 为 true (代表登录成功)
            if (result == true)
            {
                // 从 LoginWindow 的 ViewModel 里把用户拿出来
                var loginVM = loginWin.DataContext as LoginViewModel;
                if (loginVM != null && loginVM.LoginUser != null)
                {
                    // 1. 更新当前用户
                    CurrentUser = loginVM.LoginUser;

                    // 2. 更新角色名
                    RoleName = userBLL.GetRoleName(CurrentUser.UserId);

                    // 3. 可以在这里做权限控制，重新加载菜单等
                    // LoadMenus(); 
                }
            }
        }

        // 退出/注销
        private void DoExit(object obj)
        {
            if (MessageBox.Show("确定要退出登录吗？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SetGuestMode();
                // 可以选择清空已打开的 Tab
                TabItems.Clear();
                // 重新加载默认页
                LoadMenus();
            }
        }

        private void DoOpenMenu(object param)
        {
            MenuInfo menu = param as MenuInfo;
            if (menu == null || string.IsNullOrEmpty(menu.MenuUrl)) return;

            var existingTab = TabItems.FirstOrDefault(t => t.Tag?.ToString() == menu.MenuId.ToString());
            if (existingTab != null)
            {
                SelectedTab = existingTab;
                return;
            }

            // --- 不修改数据库的“重定向”逻辑开始 ---

            string targetClassName = "";

            // 1. 处理特殊的不匹配项：手动映射
            // 如果数据库里叫 HouseShowList，我们代码里叫 HouseListView，在这里强行转一下
            if (menu.MenuUrl.Contains("HouseShowList"))
            {
                targetClassName = "HouseListView";
            }
            else
            {
                // 2. 处理常规项：如果是类似 "SM/MenuList.xaml" 的格式，提取出 "MenuList"
                // 先去掉 .xaml 后缀，再取斜杠后面的名字
                string temp = menu.MenuUrl.Replace(".xaml", "");
                if (temp.Contains("/"))
                {
                    targetClassName = temp.Split('/').Last();
                }
                else
                {
                    targetClassName = temp;
                }
            }

            // 3. 拼凑最终的完整命名空间路径
            string typeName = $"HRSM.HRSMApp.Views.{targetClassName}";

            // --- “重定向”逻辑结束 ---

            Type type = Type.GetType(typeName);

            if (type == null)
            {
                // 如果还是找不到，可以在这里打个调试信息，看看 typeName 到底拼成了什么
                // MessageBox.Show($"反射失败，尝试加载的路径是：{typeName}");
                return;
            }

            UserControl pageContent = Activator.CreateInstance(type) as UserControl;

            if (pageContent != null)
            {
                TabItem newTab = new TabItem();
                newTab.Header = menu.MenuName;
                newTab.Content = pageContent;
                newTab.Tag = menu.MenuId.ToString();

                TabItems.Add(newTab);
                SelectedTab = newTab;
            }
        }

        private void DoCloseTab(object param)
        {
            string menuId = param as string;
            var tab = TabItems.FirstOrDefault(t => t.Tag?.ToString() == menuId);
            if (tab != null) TabItems.Remove(tab);
        }


        #endregion
    }
}