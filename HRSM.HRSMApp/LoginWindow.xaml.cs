using HRSM.HRSMApp.ViewModels;
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
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
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