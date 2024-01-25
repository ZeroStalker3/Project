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
using Project.DataBase;
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

            Equipment.SelectedValuePath = "Id";
            Equipment.DisplayMemberPath = "Name";
            Equipment.ItemsSource = OdbConnectorHelper.entObj.Equipment.ToList();

            FaultC.SelectedValuePath = "Id";
            FaultC.DisplayMemberPath = "Name";
            FaultC.ItemsSource = OdbConnectorHelper.entObj.Fault.ToList();

            Status.SelectedValuePath = "Id";
            Status.DisplayMemberPath = "Name";
            Status.ItemsSource = OdbConnectorHelper.entObj.Status.ToList();
        }

        private void Back_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string dataupdate = DatePicker.Text;
                string Number =NumberRequest.Text;
                string Problem = ProblemDescription.Text;
                string clien = Client.Text;

                Client client = new Client()
                {
                    Name = clien
                };

                Report rep = new Report()
                {
                    Description = Problem,
                    Date = DateTime.Parse(dataupdate) 
                };

                Repair_request req = new Repair_request()
                {
                    Serial_Number = Number,
                    Description_Problems = Problem,
                    Equipment = Equipment.SelectedItem as Equipment,
                    Fault = FaultC.SelectedItem as Fault,
                    Client = client,
                    Status = Status.SelectedItem as Status,
                    Report = rep
                };

                OdbConnectorHelper.entObj.Repair_request.Add(req);
                OdbConnectorHelper.entObj.Client.Add(client);
                OdbConnectorHelper.entObj.Report.Add(rep);
                OdbConnectorHelper.entObj.SaveChanges();

            }
            catch (Exception ex)
            {
                OdbConnectorHelper.entObj.Database.Log = s => Debug.WriteLine(s);
                MessageBox.Show("Критический сбор в работе приложения " + ex.Message.ToString(), "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
