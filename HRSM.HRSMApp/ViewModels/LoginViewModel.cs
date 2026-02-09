using HRSM.BLL;
using HRSM.HRSMApp.Utils;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.HRSMApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UserBLL userBLL = new UserBLL();

        // 修改 Action，不需要参数了，成功就是成功
        public Action? CloseAction { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(DoLogin);
        }

        #region 属性

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        // 新增：忙碌状态（用于控制按钮是否可用，防止重复点击）
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                // 忙碌状态改变时，通知 LoginCommand 重新检查是否可点击
                // (这一步需要 RelayCommand 支持，如果没有 CommandManager 逻辑，按钮不会自动变灰，但也不影响功能)
            }
        }

        #endregion

        public RelayCommand LoginCommand { get; set; }

        // 注意：这里用了 async void，这是事件处理程序的标准写法
        private async void DoLogin(object parameter)
        {
            if (IsBusy) return; // 如果正在登录中，直接返回

            var pwdBox = parameter as PasswordBox;
            string password = pwdBox != null ? pwdBox.Password : "";

            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("请输入用户名！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！", "提示");
                return;
            }

            try
            {
                // 1. 开启忙碌状态 (界面按钮应该变灰或不可点)
                IsBusy = true;

                // 2. 异步调用 BLL (await 不会卡死界面)
                var result = await userBLL.LoginAsync(UserName, password);

                // 3. 关闭忙碌状态
                IsBusy = false;

                // 4. 处理结果
                if (result.IsSuccess)
                {
                    // 优化：弹出成功提示
                    MessageBox.Show(result.Msg, "提示", MessageBoxButton.OK, MessageBoxImage.Information);

                    // 通知关闭窗口
                    CloseAction?.Invoke();
                }
                else
                {
                    MessageBox.Show(result.Msg, "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show($"发生未知错误：{ex.Message}", "错误");
            }
        }
    }
}