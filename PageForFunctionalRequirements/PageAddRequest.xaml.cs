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

namespace Project.PageForFunctionalRequirements
{
    /// <summary>
    /// Interaction logic for PageAddRequest.xaml
    /// </summary>
    public partial class PageAddRequest : Page
    {
        public PageAddRequest()
        {
            InitializeComponent();
        }

        private void Back_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
