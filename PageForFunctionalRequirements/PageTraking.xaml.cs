﻿    using System;
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
        
        public PageTraking()
        {
            InitializeComponent();

            List.ItemsSource = OdbConnectorHelper.entObj.Repair_request.ToList();

        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }


        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PpageEditInfo((sender as Button).DataContext as Repair_request));
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            OdbConnectorHelper.entObj.SaveChanges();
        }
    }
}
