using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AppLib.Email;

namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for ViewReciverList.xaml
    /// </summary>
    public partial class ViewReciverList : Page
    {
        public ViewReciverList()
        {
            InitializeComponent();
            ReciverData.ItemsSource = App.Recivers;
            ReciverData.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Navn", System.ComponentModel.ListSortDirection.Descending));
        }

        private void AddReciver(object sender, RoutedEventArgs e)
        {
            Frames.AddReciver addReciver = new Frames.AddReciver();
            NavigationService.Navigate(addReciver);
        }

        private void ReciverData_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }
}
