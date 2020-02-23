﻿using System;
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
    /// Interaction logic for MainKeyValid.xaml
    /// </summary>
    public partial class MainKeyValid : Page
    {
        public MainKeyValid()
        {
            InitializeComponent();
            ContentFrame.Content = new Frames.Default();
        }

        private void loadListPage(object sender, RoutedEventArgs e)
        {
            // load list page
        }

        private void loadListFile(object sender, RoutedEventArgs e)
        {
            // load list file
        }

        private void loadTemplatePage(object sender, RoutedEventArgs e)
        {
            // load page for templates
        }

        private void sendEmails(object sender, RoutedEventArgs e)
        {
            // send emails
        }

        private void loadSettingsPage(object sender, RoutedEventArgs e)
        {
            if (!App.ConfigFileExist)
            {
                ContentFrame.Content = new Frames.SetNewPassword();
            }
            else
            {
                ContentFrame.Content = new Frames.EnterPassword();
            }
        }

        private void quitApp(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
