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
using AppLib.Collection;

namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for SetNewPassword.xaml
    /// </summary>
    public partial class SetNewPassword : Page
    {
        public SetNewPassword()
        {
            InitializeComponent();
        }

        private void SetPassword(object sender, RoutedEventArgs e)
        {
            string pass1 = password.Password;
            string pass2 = passwordRepeat.Password;

            if (pass1 != pass2)
            {
                passwordError.Text = "Passordene er ikke like, prøv igjen...";
                password.Password = "";
                passwordRepeat.Password = "";
            }
            else if (pass1.Length < 8)
            {
                passwordError.Text = "Passordet må inneholde minst 8 tegn...";
                password.Password = "";
                passwordRepeat.Password = "";
            }
            else
            {
                string hashed = Password.Hashed(App.Key, pass1);
                ConfigFile.CreateNewConfigFile(hashed);
                Frames.Settings settings = new Frames.Settings();
                NavigationService.Navigate(settings);
            }

        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            Frames.Default def = new Frames.Default();
            NavigationService.Navigate(def);
        }
    }
}
