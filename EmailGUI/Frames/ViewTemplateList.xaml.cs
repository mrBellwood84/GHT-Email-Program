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

        }
    }
}
