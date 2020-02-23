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
// own lib
using AppLib.Secrets;

namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for EnterPassword.xaml
    /// </summary>
    public partial class EnterPassword : Page
    {
        public EnterPassword()
        {
            InitializeComponent();
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            Frames.Default def = new Frames.Default();
            NavigationService.Navigate(def);
        }

        private void SetPassword(object sender, RoutedEventArgs e)
        {
            string pass1 = password.Password;
            if (pass1.Length > 0)
            {
                bool verified = Password.VerifyPassword(App.Key, pass1);
                
                if (!verified)
                {
                    password.Password = "";
                    passwordError.Text = "Feil passord!";
                }
                else
                {
                    Frames.Settings settings = new Frames.Settings();
                    NavigationService.Navigate(settings);
                }
            }

        }
    }

}
