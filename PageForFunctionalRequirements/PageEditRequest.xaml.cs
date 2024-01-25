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

           
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
                

            //}
            //catch (Exception ex)
            //{
            //OdbConnectorHelper.entObj.Database.Log = s => Debug.WriteLine(s);
            //MessageBox.Show("Критический сбор в работе приложения " + ex.Message.ToString(), "Уведомление",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Warning);
            //}
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
