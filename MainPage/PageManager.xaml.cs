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
using Project.PageForManager;

namespace Project.MainPage
{
    /// <summary>
    /// Interaction logic for PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Static_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageStatic());
        }

        private void EditEval_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddEmploye());
        }

        private void Request_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageListRequest());
        }
    }
}
