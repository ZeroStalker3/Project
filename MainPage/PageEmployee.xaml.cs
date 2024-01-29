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
using Project.PageForFunctionalRequirements.PageEditForAddEmploye;

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

        private void EditEval_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddEmploye());
        }

        private void Request_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageTrackingBids());
        }

        private void Static_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageStatic());
        }
    }
}
