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
using Project.DataBase;
using Project.DataFilesApp;
using Project.PageForFunctionalRequirements.ClassHelp;

namespace Project.PageForFunctionalRequirements.PageEditForAddEmploye
{
    /// <summary>
    /// Interaction logic for PageEditAdd.xaml
    /// </summary>
    public partial class PageEditAdd : Page
    {
        private Repair_request _seRepairRequest;
        public PageEditAdd(Repair_request repairRequest)
        {
            InitializeComponent();

            
            _seRepairRequest = repairRequest;
            CmbStatus.SelectedValuePath = "Id";
            CmbStatus.DisplayMemberPath = "Name";
            CmbStatus.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();

            CmbExecutor.SelectedValuePath = "Id";
            CmbExecutor.DisplayMemberPath = "Name";
            CmbExecutor.ItemsSource = OdbConnectorHelper.entObj.Performer.ToList();
        }

        private void BtnEditApplication_OnClick(object sender, RoutedEventArgs e)
        {
            if (CmbStatus.SelectedIndex == 2)
            {
                if (_seRepairRequest != null)
                {
                    _seRepairRequest.Comment = TxbProblem.Text;
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
            else
            {
                if (CmbStatus.SelectedIndex == 0 || CmbStatus.SelectedIndex == 1)
                {
                    if (_seRepairRequest != null)
                    {
                        _seRepairRequest.Status = CmbStatus.SelectedItem as Status;
                        _seRepairRequest.Performer = CmbExecutor.SelectedItem as Performer;

                        OdbConnectorHelper.entObj.SaveChanges();

                        MessageBox.Show("Заявка обновлена, без комментариев",
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

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
