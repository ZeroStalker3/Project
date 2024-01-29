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

namespace Project.PageForFunctionalRequirements.PageEditForAddEmploye
{
    /// <summary>
    /// Interaction logic for PageMessageAndComment.xaml
    /// </summary>
    public partial class PageMessageAndComment : Page
    {
        private Repair_request _seRepairRequest;

        public PageMessageAndComment()
        {
            InitializeComponent();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (_seRepairRequest != null)
            {
                _seRepairRequest.Comment = TxbProblem.Text;

                OdbConnectorHelper.entObj.SaveChanges();

                MessageBox.Show("Заявка обновлена",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
