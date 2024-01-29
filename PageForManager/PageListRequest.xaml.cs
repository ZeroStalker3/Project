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

namespace Project.PageForManager
{
    /// <summary>
    /// Interaction logic for PageListRequest.xaml
    /// </summary>
    public partial class PageListRequest : Page
    {
        public PageListRequest()
        {
            InitializeComponent();

            ApplicationHistory.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
