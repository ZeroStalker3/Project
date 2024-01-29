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
    /// Interaction logic for PageStatic.xaml
    /// </summary>
    public partial class PageStatic : Page
    {
        public PageStatic()
        {
            InitializeComponent();

            ApplicationHistory.Columns[1].CanUserSort = false;
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += IzmenenieDannih;
            timer.Tick += DisplayAverageCompletionTime;
            timer.Tick += DisplayFaultStatistics;
            timer.Start();

        }
        private void IzmenenieDannih(object sender, object e)
        {
            var historyEvent = OdbConnectorHelper.entObj.Repair_request.ToList();
            var completedRequests = historyEvent.Where(app => app.Status != null && app.Status.Id == 3).ToList();
            ApplicationHistory.ItemsSource = completedRequests;
            TxtTotal.Text = Convert.ToString(completedRequests.Count);
        }

        
        private void DisplayAverageCompletionTime(object sender, EventArgs e)
        {
            var historyEvent = OdbConnectorHelper.entObj.Repair_request.ToList();

            var completedRequests = historyEvent
                .Where(app => app.Status != null && app.Status.Id == 3 && app.Date != null && app.DateCompletion != null)
                .ToList();

            if (completedRequests.Any())
            {
                double averageCompletionTimeInDays = completedRequests
                    .Average(app => (app.DateCompletion.Value - app.Date.Value).TotalDays);

                TxtTime.Text = $"Среднее время выполнения заявки: {averageCompletionTimeInDays} дней";
            }
            else
            {
                TxtTime.Text = "Нет выполненных заявок";
            }
        }

        private void DisplayFaultStatistics(object sender, EventArgs e)
        {
            var historyEvent = OdbConnectorHelper.entObj.Repair_request.ToList();

            int mechanicalFaultCount = historyEvent.Count(app => app.Fault.Id == 1);
            int electricalFaultCount = historyEvent.Count(app => app.Fault.Id == 2);
            int softwareFaultCount = historyEvent.Count(app => app.Fault.Id == 3);
            TxtTipe.Text = $"Статистика по типам неисправностей:\nМеханическая: {mechanicalFaultCount}\nЭлектрическая: {electricalFaultCount}\nПрограммное: {softwareFaultCount}";
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
