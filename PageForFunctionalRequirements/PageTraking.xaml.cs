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

namespace Project.PageForFunctionalRequirements
{
    /// <summary>
    /// Interaction logic for PageTraking.xaml
    /// </summary>
    public partial class PageTraking : Page
    {
        private Dictionary<DataGridRow, object> selectedValues = new Dictionary<DataGridRow, object>();
        
        public PageTraking()
        {
            InitializeComponent();

            Box.SelectedValuePath = "Id";
            Box.DisplayMemberPath = "Serial_Number";
            Box.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();

            //CmbStatus.SelectedValuePath = "Id";
            //CmbStatus.DisplayMemberPath = "Name";
            //CmbStatus.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();

            //List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();

        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Box_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int select = Convert.ToInt32(Box.SelectedValue);
            List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.Where(x
                => x.Id == select).ToList();
            List.SelectedIndex = 0;
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
                Pending.IsChecked = false;
                Done.IsChecked = false;
                List.ItemsSource = OdbConnectorHelper.entObj.Client.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void Done_OnClick(object sender, RoutedEventArgs e)
        {
            if (Done.IsChecked == true)
            {
                Pending.IsChecked = false;
                Progress.IsChecked = false;
                List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.OrderByDescending(x => x.Id_Status).ToList();
            }
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
           // FrameApp.frmObj.Navigate(new PpageEditInfo((sender as Button).DataContext as Repair_request));
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            OdbConnectorHelper.entObj.SaveChanges();
        }

        private void CmbStatus_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int select = Convert.ToInt32(Box.SelectedValue);
            List.ItemsSource = OdbConnectorHelper.entObj.Status.Where(x
                => x.Id == select).ToList();
            List.SelectedIndex = 0;
        }

        private void CmbStatus_OnLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmbStatus = sender as ComboBox;

            if (cmbStatus != null)
            {
                // Сохраняем выбранное значение
                object selectedValue = cmbStatus.SelectedValue;

                // Устанавливаем свойства
                cmbStatus.SelectedValuePath = "Id";
                cmbStatus.DisplayMemberPath = "Name";
                cmbStatus.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();

                // Восстанавливаем выбранное значение, если оно было сохранено
                if (selectedValue != null)
                {
                    cmbStatus.SelectedValue = selectedValue;
                }
            }
        }
    }
}
