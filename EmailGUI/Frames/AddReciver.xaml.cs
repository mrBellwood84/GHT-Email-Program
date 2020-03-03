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
    /// Interaction logic for AddReciver.xaml
    /// </summary>
    public partial class AddReciver : Page
    {
        public AddReciver()
        {
            InitializeComponent();
        }

        private void CreateReciver(object sender, RoutedEventArgs e)
        {
            Reciver reciver = new Reciver();
            string name = nameInput.Text;
            string mail = emailInput.Text;
            string lang = languageSelector.Text;

            if ((name == "") || (mail == ""))
            {
                MessageBox.Show("Data mangler!");
            }
            else
            {
                reciver.FullName = name;
                reciver.Email = mail;
                reciver.Language = lang.Substring(0, 2).ToUpper();
                App.Recivers.Add(reciver);

                Frames.ViewReciverList reciverList = new Frames.ViewReciverList();
                NavigationService.Navigate(reciverList);
            }
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            Frames.ViewReciverList reciverList = new Frames.ViewReciverList();
            NavigationService.Navigate(reciverList);
        }
    }
}
