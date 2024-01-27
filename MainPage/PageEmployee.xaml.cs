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
using Project.PageForFunctionalRequirements;

namespace Project.MainPage
{
    /// <summary>
    /// Interaction logic for PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        public PageEmployee()
        {
            InitializeComponent();
        }

        private void BtnAddRequest_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddRequest());
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnTrackingStReq_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageTraking());
        }
    }
}
