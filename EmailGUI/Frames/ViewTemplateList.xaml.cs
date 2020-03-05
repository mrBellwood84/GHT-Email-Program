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
    /// Interaction logic for ViewTemplateList.xaml
    /// </summary>
    public partial class ViewTemplateList : Page
    {
        public ViewTemplateList()
        {
            InitializeComponent();
        }

        private void CreateNewTemplate(object sender, RoutedEventArgs e)
        {
            Frames.EditTemplate newTemplate = new Frames.EditTemplate();
            NavigationService.Navigate(newTemplate);
        }

        private void EditTemplate(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.InitialDirectory = GetPath.TemplateFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "JsonData Mail (.json)| *.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string filetext = File.ReadAllText(filename);
                string[] split = filetext.Split('|');

                EmailBodyTemplate template = new EmailBodyTemplate();
                template.EN = JsonSerializer.Deserialize<EmailBodyTemplate.EnglishContent>(split[0]);
                template.NO = JsonSerializer.Deserialize<EmailBodyTemplate.NorwegianContent>(split[1]);


                Frames.EditTemplate edit = new EditTemplate(template);
                NavigationService.Navigate(edit);
            }
        }

        private void PreviewTemplate(object sender, RoutedEventArgs e)
        {
            // create body template for norwegian and english
            Reciver res_no = new Reciver();
            Reciver res_en = new Reciver();
            res_no.Language = "NO";

            // get email body template

            EmailBodyTemplate template = loadTemplateFile();

            if (template != null)
            {
                // set emailbody objects and populate
                CreateEmailBody emailBody_NO = new CreateEmailBody(template);
                CreateEmailBody emailBody_EN = new CreateEmailBody(template);
                emailBody_NO.ReciverObj = res_no;
                emailBody_EN.ReciverObj = res_en;

                string body_no = emailBody_NO.CreatePreview();
                string body_en = emailBody_EN.CreatePreview();

                string body_no_path = System.IO.Path.Combine(GetPath.PreviewFolder, "preview_NO.html");
                string body_en_path = System.IO.Path.Combine(GetPath.PreviewFolder, "preview_EN.html");

                File.WriteAllText(body_no_path, body_no);
                File.WriteAllText(body_en_path, body_en);

                previewbrowser_NO.Navigate(body_no_path);
                previewbrowser_EN.Navigate(body_en_path);
            }
            
        }

        private EmailBodyTemplate loadTemplateFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.InitialDirectory = GetPath.TemplateFolder;
            dlg.DefaultExt = ".json";
            dlg.Filter = "JsonData Mail (.json)| *.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string filetext = File.ReadAllText(filename);
                string[] split = filetext.Split('|');

                EmailBodyTemplate template = new EmailBodyTemplate();
                template.EN = JsonSerializer.Deserialize<EmailBodyTemplate.EnglishContent>(split[0]);
                template.NO = JsonSerializer.Deserialize<EmailBodyTemplate.NorwegianContent>(split[1]);

                return template;
            }
            else
            {
                return null;
            }
        }
    }
}
