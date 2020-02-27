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

            List<Reciver> recivers = App.Recivers;

            recivers.Add(new Reciver("kristian", "mail@mail.com"));
            recivers.Add(new Reciver("hege", "test@mail.com"));
            recivers.Add(new Reciver("Ballemann","email@balle.com"));

            ReciverList.ItemsSource = recivers;
        }
    }
}
