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

        }

        private void PreviewTemplate(object sender, RoutedEventArgs e)
        {

        }

    }
}
