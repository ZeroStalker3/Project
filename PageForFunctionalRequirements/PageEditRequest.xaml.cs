using Project.DataFilesApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Project.PageForFunctionalRequirements
{
    /// <summary>
    /// Interaction logic for PageEditRequest.xaml
    /// </summary>
    public partial class PageEditRequest : Page
    {
        public PageEditRequest()
        {
            InitializeComponent();

            ComboBox.SelectedValuePath = "Id";
            ComboBox.DisplayMemberPath = "Serial_Number";
            ComboBox.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();

        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int select = Convert.ToInt32(ComboBox.SelectedValue);
            List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.Where(x 
                => x.Id == select).ToList();
            List.SelectedIndex = 0;

        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            OdbConnectorHelper.entObj.SaveChanges();
        }
    }
}
