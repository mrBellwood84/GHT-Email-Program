﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Mail;
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
using AppLib;
using AppLib.Collection;
using AppLib.Email;



namespace EmailGUI.Frames
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            ConfigFile cf = new ConfigFile(false);  // load configfile with just content count.
            if (cf.ContentCount > 1)                // if configfile contain more than password hash
            {
                cf = new ConfigFile(true);          // get configfile with content
                smtpClient.Text     = cf.SmtpServer;
                username.Text       = cf.UserName;
                password.Password   = cf.Password;
                port.Text           = cf.Port.ToString();
                SSL.IsChecked       = cf.SSL;
                senderEmail.Text    = cf.SenderEmail;
            }
        }

        private void SaveSettings(object sender, RoutedEventArgs e)
        {

            /** Checks if input have values, and format of input.
             *  Do not test if smtp connection is working           */

            bool allvalid = true;   // set to false if something is missing

            // check smtp client input
            if (smtpClient.Text == "")
            {
                smtpClientError.Text = "X";
                allvalid = false;
            }
            else
            {
                smtpClientError.Text = "";
            }

            // check username input
            if (username.Text == "")
            {
                usernameError.Text = "X";
                allvalid = false;
            }
            else
            {
                usernameError.Text = "";
            }

            // check password input
            if (password.Password.ToString() == "")
            {
                passwordError.Text = "X";
                allvalid = false;
            }
            else
            {
                passwordError.Text = "";
            }

            // check portnumber input
            int portNumber = 0;
            bool isNumber = Int32.TryParse(port.Text, out portNumber);
            if (!isNumber)
            {
                portError.Text = "X";
                allvalid = false;
            }
            else
            {
                portError.Text = "";
            }

            // check sender email
            if ((!senderEmail.Text.Contains("@")) || (!senderEmail.Text.Contains(".")))
            {
                senderEmailError.Text = "X";
                allvalid = false;
            }
            else
            {
                senderEmailError.Text = "";
            }



            if (allvalid)
            {
                ConfigFile cf = new ConfigFile(smtpClient.Text,
                                                username.Text,
                                                password.Password.ToString(),
                                                portNumber,
                                                SSL.IsEnabled,
                                                senderEmail.Text);
                cf.SaveConfigFile();

                saveMessage.Foreground = new SolidColorBrush(Colors.Green);
                saveMessage.Text = "Innstillingene er lagret";
            }
            else
            {
                saveMessage.Foreground = new SolidColorBrush(Colors.Red);
                saveMessage.Text = "Ett eller flere felt er ikke fylt ut riktig. Se markering";
            }

        }

        private void TestConnection(object sender, RoutedEventArgs e)
        {
            // creating test email template
            EmailBodyTemplate template = new EmailBodyTemplate();
            template.EN.GuestGreeting = "Testing av epost Program";
            template.EN.SenderGreeting = "Med de beste hilsener";
            template.EN.SenderDefaultName = "Kristian";
            template.EN.MailText = "Dette er en test for å sjekke om epost-server og/eller innstillinger i program.\n\n" +
                "Dersom du har mottatt denne eposten, er ser det ut til at alt virker som det skal\n\n" +
                "Dersom du har mottatt denne eposten uten noen åpenbar grunn, ta gjerne kontakt.";

            // create test reciver object
            Reciver reciver = new Reciver();
            reciver.Email = senderEmail.Text;
            reciver.FullName = " ";

            // create email body
            CreateEmailBody emailBody = new CreateEmailBody(template);
            // append reciver
            emailBody.ReciverObj = reciver;

            MailMessage mail = emailBody.CreateMail(senderEmail.Text, "TEST");
        }
    }
}
