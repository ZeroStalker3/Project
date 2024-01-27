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
        private int serialnumber;
        public PpageEditInfo(Repair_request repairRequest)
        {
            InitializeComponent();
            serialnumber = Convert.ToInt32((repairRequest.Serial_Number));


            //Name.Text = request.Name;

            GridListStudent.ItemsSource = OdbConnectorHelper.entObj.Repair_request.Where(x => x.Id == serialnumber).ToList();
            GridListStudent.SelectedIndex = 0;
            GridListStudent.Columns[0].IsReadOnly = true;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            
            OdbConnectorHelper.entObj.SaveChanges();
            MessageBox.Show("Данные успешно изменены",
                "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
