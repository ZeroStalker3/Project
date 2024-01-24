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
using Project.MainPage;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool size = false;
        public MainWindow()
        {
            InitializeComponent();

            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new PageLogin());

            OdbConnectorHelper.entObj = new ProjectEducationalPracticeEntities();
        }

        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Resize_OnClick(object sender, RoutedEventArgs e)
        {
            if (size == false)
            {
                this.WindowState = WindowState.Maximized;
                size = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                size = false;
            }
        }

        private void Min_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
