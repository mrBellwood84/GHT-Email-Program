using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
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

        private void SaveTemplate(object sender, RoutedEventArgs e)
        {
            EmailBodyTemplate template = new EmailBodyTemplate();

            template.GuestGreeting = new string[] { guestGreeting_EN.Text, guestGreeting_NO.Text };
            template.DefaultGuestName = new string[] { defaultGuestName_EN.Text, defaultGuestName_NO.Text };
            template.SenderGreeting = new string[] { senderGreeting_EN.Text, senderGreeting_NO.Text };
            template.DefaultSenderName = new string[] { defaultSenderName_EN.Text, defaultSenderName_NO.Text };
            template.MailMessage = new string[] { mailMessage_EN.Text, mailMessage_NO.Text };

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "template";
            dlg.InitialDirectory = GetPath.TemplateFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSONDATA mail (.json)| *.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result ==  true)
            {
                string fileName = dlg.FileName;
                string serialize = JsonSerializer.Serialize(template);
                File.WriteAllText(fileName, serialize);

                Frames.ViewTemplateList tpl = new Frames.ViewTemplateList();
                NavigationService.Navigate(tpl);
            }

        }
    }


}
