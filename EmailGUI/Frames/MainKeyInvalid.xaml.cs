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
// applib
using AppLib.Collection;

namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for MainKeyInvalid.xaml
    /// </summary>
    public partial class MainKeyInvalid : Page
    {
        public MainKeyInvalid(bool expired)
        {
            InitializeComponent();

            if (expired)
            {
                msg1.Text = "Prøvetiden har utløpt.";
                msg2.Text = "Kontakt utvikler.";
            }
            else
            {
                string logPath = GetPath.Log;
                msg1.Text = "Sikkerhetsfeil! Nøkkelfilen mangler integritet.";
                msg2.Text = "Feil registert i log.";
            }
        }

        public void QuitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
