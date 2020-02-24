using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AppLib.Email
{
    public class BuildMail
    {
        private bool buildSuccess = true;
        private MailMessage mail;

        public BuildMail(
            string senderEmail,
            string reciverEmail,
            string reciverName,
            string subject,
            string htmlBody)
        {
            try
            {
                this.mail.From = new MailAddress(senderEmail);
                this.mail.To.Add(reciverEmail);
                this.mail.Subject = subject;
                this.mail.Body = htmlBody;          // change this to add custom name and image for header - other content?!!
                this.mail.IsBodyHtml = true;

                // add name to email
                // add image to email
            }
            catch (Exception ex)
            {
                this.buildSuccess = false;
                Logger.AppendLogEntry("EMAIL_BUILD_ERROR",ex.ToString());
            }
            
        }

    }
}
