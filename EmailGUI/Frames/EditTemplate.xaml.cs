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

namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for EditTemplate.xaml
    /// </summary>
    public partial class EditTemplate : Page
    {
        public EditTemplate()
        {
            InitializeComponent();

            // set default guest greeting when editing new template
            guestGreeting_NO.Text = "Kjære";
            guestGreeting_EN.Text = "Dear";

            defaultGuestName_NO.Text = "Gjest";
            defaultGuestName_EN.Text = "Guest";

            senderGreeting_NO.Text = "Med beste hilsener";
            senderGreeting_EN.Text = "Best regards";

            defaultSenderName_NO.Text = "Resepsjonen";
            defaultSenderName_EN.Text = "Reception";
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            Frames.ViewTemplateList vtp = new Frames.ViewTemplateList();
            NavigationService.Navigate(vtp);
        }
    }
}
