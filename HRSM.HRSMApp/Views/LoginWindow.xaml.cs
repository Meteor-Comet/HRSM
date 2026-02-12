using HRSM.HRSMApp.ViewModels;
using HRSM.Models;
using System.Windows;
using System.Windows.Input;

namespace HRSM.HRSMApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginViewModel vm = new LoginViewModel();

            // 修改这里的逻辑：因为只有成功才会触发这个 Action
            vm.CloseAction = () =>
            {
                // ✅ 必须是这样：设置 DialogResult = true
                vm.CloseAction = () =>
                {
                    this.DialogResult = true; // 告诉调用者“我成功了”
                    this.Close();             // 关闭自己
                };
            };

            this.DataContext = vm;
        }

        // 顶部关闭按钮的点击事件 (属于纯 UI 逻辑，可以写在后台)
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // 让无边框窗口可以拖动
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}