using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;

using AppLib.Collection;
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

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.InitialDirectory = GetPath.SaveListFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "Mottakerliste (.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string fileText = File.ReadAllText(filename);
                App.Recivers = JsonSerializer.Deserialize<List<Reciver>>(fileText);
                ReciverData.ItemsSource = App.Recivers;
                ReciverData.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Navn", System.ComponentModel.ListSortDirection.Descending));
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "";
            dlg.InitialDirectory = GetPath.SaveListFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "Mottakerliste (.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string stringSerialize = JsonSerializer.Serialize(App.Recivers);
                File.WriteAllText(filename, stringSerialize);
            }
        }

        private void EmptyList(object sender, RoutedEventArgs e)
        {
            // set message box
            string msg = "Vil du tømme listen?\n Dersom du ikke har lagret, vil all data bli slettet.";
            string caption = "Tøm liste";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Warning;

            MessageBoxResult msgResult = MessageBox.Show(msg, caption, buttons, image);

            if (msgResult == MessageBoxResult.Yes)
            {
                App.Recivers = new List<Reciver>();
                ReciverData.ItemsSource = App.Recivers;
                ReciverData.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Navn", System.ComponentModel.ListSortDirection.Descending));
            }

        }

        private void nameSearch(object sender, KeyEventArgs e)
        {
            string text = SearchField.Text;
            if (text == "")
            {
                ReciverData.ItemsSource = App.Recivers;
                ReciverData.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Navn", System.ComponentModel.ListSortDirection.Descending));
            }
            else
            {
                List<Reciver> sublist = new List<Reciver>();
                foreach (Reciver r in App.Recivers)
                {
                    if (r.FullName.ToLower().Contains(text.ToLower()))
                    sublist.Add(r);
                }
                ReciverData.ItemsSource = sublist;
                ReciverData.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Navn", System.ComponentModel.ListSortDirection.Descending));
            }

        }
    }
}
