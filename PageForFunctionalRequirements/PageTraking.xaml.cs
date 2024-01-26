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
    /// Interaction logic for PageTraking.xaml
    /// </summary>
    public partial class PageTraking : Page
    {
        public PageTraking()
        {
            InitializeComponent();

            List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();

        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Box_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Pending_OnClick(object sender, RoutedEventArgs e)
        {
            if (Pending.IsChecked == true)
            {
                Progress.IsChecked = false;
                Done.IsChecked = false;
                List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.OrderByDescending(x => x.Id_Status).ToList();
            }
        }

        private void Progress_OnClick(object sender, RoutedEventArgs e)
        {
            if (Progress.IsChecked == true)
            {
                
            }
        }

        private void Done_OnClick(object sender, RoutedEventArgs e)
        {
            if (Done.IsChecked == true)
            {

            }
        }
    }
}
