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
using System.Xml.Linq;
using Project.DataBase;
using Project.DataFilesApp;

namespace Project.PageForFunctionalRequirements
{
    /// <summary>
    /// Interaction logic for PpageEditInfo.xaml
    /// </summary>
    public partial class PpageEditInfo : Page
    {
        private Repair_request _seRepairRequest;
        public PpageEditInfo(Repair_request repairRequest)
        {
            InitializeComponent();
          
            _seRepairRequest = repairRequest;
            CmbStatus.SelectedValuePath = "Id";
            CmbStatus.DisplayMemberPath = "Name";
            CmbStatus.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();

            CmbPriority.SelectedValuePath = "Id";
            CmbPriority.DisplayMemberPath = "Status";
            CmbPriority.ItemsSource = OdbConnectorHelper.entObj.Priority.ToList();

            CmbExecutor.SelectedValuePath = "Id";
            CmbExecutor.DisplayMemberPath = "Name";
            CmbExecutor.ItemsSource = OdbConnectorHelper.entObj.Performer.ToList();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnEditApplication_OnClick(object sender, RoutedEventArgs e)
        {
            if (_seRepairRequest != null)
            {
                _seRepairRequest.Description_Problems = TxbProblem.Text;
                _seRepairRequest.Priority = CmbPriority.SelectedItem as Priority;
                _seRepairRequest.Status = CmbStatus.SelectedItem as Status;
                _seRepairRequest.Performer = CmbExecutor.SelectedItem as Performer;

                OdbConnectorHelper.entObj.SaveChanges();

                MessageBox.Show("Заявка обновлена",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Заявка не найдена",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
