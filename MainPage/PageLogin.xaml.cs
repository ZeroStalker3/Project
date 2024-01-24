using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.DataFilesApp;

namespace Project.MainPage
{
    /// <summary>
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();

            if (Properties.Settings.Default.SaveLogin != string.Empty)
            {
                LoginTxb.Text = Properties.Settings.Default.SaveLogin;
            }
        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectorHelper.entObj.User.FirstOrDefault(
                    x => x.Login == LoginTxb.Text && x.Password == PasswordBx.Password
                );
                if (userObj == null)
                {
                   
                    MessageBox.Show("Такой пользователь отсутствует в приложения",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            UserControlHelp.LoginUser = LoginTxb.Text;
                            FrameApp.frmObj.Navigate(new PageEmployee());
                            break;
                        case 2:
                            FrameApp.frmObj.Navigate(new PageManager());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения", "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
