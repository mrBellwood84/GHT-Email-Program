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

        public EditTemplate(EmailBodyTemplate template)
        {
            InitializeComponent();

            guestGreeting_EN.Text = template.EN.GuestGreeting;
            guestGreeting_NO.Text = template.NO.GuestGreeting;

            defaultGuestName_EN.Text = template.EN.GuestDefaultName;
            defaultGuestName_NO.Text = template.NO.GuestDefaultName;

            senderGreeting_EN.Text = template.EN.SenderGreeting;
            senderGreeting_NO.Text = template.NO.SenderGreeting;

            defaultSenderName_EN.Text = template.EN.SenderDefaultName;
            defaultSenderName_NO.Text = template.NO.SenderDefaultName;

            mailMessage_EN.Text = template.EN.MailText;
            mailMessage_NO.Text = template.NO.MailText;
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            Frames.ViewTemplateList vtp = new Frames.ViewTemplateList();
            NavigationService.Navigate(vtp);
        }

        private void SaveTemplate(object sender, RoutedEventArgs e)
        {
            EmailBodyTemplate template = new EmailBodyTemplate();

            template.EN.GuestGreeting = guestGreeting_EN.Text;
            template.NO.GuestGreeting = guestGreeting_NO.Text;

            template.EN.GuestDefaultName = defaultGuestName_EN.Text;
            template.NO.GuestDefaultName = defaultGuestName_NO.Text;

            template.EN.SenderGreeting = senderGreeting_EN.Text;
            template.NO.SenderGreeting = senderGreeting_NO.Text;
            
            template.EN.SenderDefaultName = defaultSenderName_EN.Text;
            template.NO.SenderDefaultName = defaultSenderName_NO.Text;

            template.EN.MailText = mailMessage_EN.Text;
            template.NO.MailText = mailMessage_NO.Text;


            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "template";
            dlg.InitialDirectory = GetPath.TemplateFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "JsonData Mail (.json)| *.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result ==  true)
            {
                string fileName = dlg.FileName;

                string en = JsonSerializer.Serialize(template.EN);
                string no = JsonSerializer.Serialize(template.NO);

                string concat = $"{en}<JSON-SEPERATOR>{no}";
                
                File.WriteAllText(fileName, concat);

                Frames.ViewTemplateList tpl = new Frames.ViewTemplateList();
                NavigationService.Navigate(tpl);
            }

        }
    }


}
