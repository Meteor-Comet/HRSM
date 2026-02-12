using HRSM.BLL;
using HRSM.HRSMApp.Utils;
using HRSM.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRSM.HRSMApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // 引用业务逻辑层
        private UserBLL userBLL = new UserBLL();

        // 定义一个动作，当登录成功时执行（用于关闭窗口）
        public Action? CloseAction { get; set; }

        // 对外暴露登录成功的用户对象，供 UI 层获取并传给主窗口
        public UserInfo? LoginUser { get; private set; }

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

        // 忙碌状态（用于控制按钮是否可用，防止重复点击）
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 命令

        public RelayCommand LoginCommand { get; set; }

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
                // 1. 开启忙碌状态 (按钮变灰)
                IsBusy = true;

                // 2. 异步调用 BLL
                // 返回值元组：(bool IsSuccess, string Msg, UserInfo? User)
                var result = await userBLL.LoginAsync(UserName, password);

                // 3. 关闭忙碌状态
                IsBusy = false;

                // 4. 处理结果
                if (result.IsSuccess)
                {
                    // 核心步骤：把登录成功的用户保存到属性中
                    LoginUser = result.User;

                    // 弹出成功提示
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

        #endregion
    }
}