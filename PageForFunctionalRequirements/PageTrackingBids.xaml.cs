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
using System.Windows.Threading;
using Project.DataFilesApp;

namespace Project.PageForFunctionalRequirements
{
    /// <summary>
    /// Interaction logic for PageTrackingBids.xaml
    /// </summary>
    public partial class PageTrackingBids : Page
    {
        public PageTrackingBids()
        {
            InitializeComponent();
            CmbSelectStatus.DisplayMemberPath = "Name";
            CmbSelectStatus.SelectedValuePath = "Id";
            CmbSelectStatus.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();
            ApplicationHistory.Columns[1].CanUserSort = false;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += IzmenenieDannih;
            timer.Start();
        }

        private void IzmenenieDannih(object sender, object e)
        {
            var historyEvent = OdbConnectorHelper.entObj.Repair_request.ToList();
            ApplicationHistory.ItemsSource = historyEvent;
            TxtTotal.Text = Convert.ToString(historyEvent.Count);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void CmbSelectStatus_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedStatus = Convert.ToInt32(CmbSelectStatus.SelectedValue);
            ApplicationHistory.ItemsSource = OdbConnectorHelper.entObj.Repair_request.Where(x => 
                x.Id_Status == SelectedStatus).ToList();
            ApplicationHistory.SelectedIndex = 0;
        }

        private void RbDes_OnClick(object sender, RoutedEventArgs e)
        {
            if (RbDes.IsChecked == true)
            {
                RbUp.IsChecked = false;
                ApplicationHistory.ItemsSource = OdbConnectorHelper.entObj.Repair_request.OrderByDescending(x => x.Date).ToList();
            }
        }

        private void RbUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (RbUp.IsChecked == true)
            {
                RbDes.IsChecked = false;
                ApplicationHistory.ItemsSource = OdbConnectorHelper.entObj.Repair_request.OrderBy(x => x.Date).ToList();
            }
        }
    }
}
