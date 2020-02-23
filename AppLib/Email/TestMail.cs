using System;
using System.Net.Mail;

namespace AppLib.Email
{
    public class TestMail
    {

        private MailMessage mail = new MailMessage();
        private SmtpClient smtpServer;

        private bool buildSuccess = true;
        private string buildError;

        private bool sendSuccess = true;
        private string sendError;

        public bool BuildSuccess { get => buildSuccess; }
        public string BuildError { get => buildError; }
        public bool SendSuccess { get => sendSuccess; }
        public string SendError { get => sendError; }


        public TestMail()
        {
            // get config file
            Collection.ConfigFile configFile = new Collection.ConfigFile();

            // build email and smpt server object
            try
            {
                // create email
                this.mail.From = new MailAddress(configFile.SenderEmail);
                this.mail.To.Add(configFile.SenderEmail);
                this.mail.Subject = "Tester Epost program";
                this.mail.Body = "Dette er en test av smtp server. Testen var vellykket!";

                // set smtp server
                this.smtpServer = new SmtpClient(configFile.SmtpServer);
                this.smtpServer.Port = configFile.Port;
                this.smtpServer.Credentials = new System.Net.NetworkCredential(configFile.UserName, configFile.Password);
                this.smtpServer.EnableSsl = configFile.SSL;
            }
            catch (Exception ex)
            {
                this.buildSuccess = false;
                this.buildError = ex.ToString();
            }
        }

        public void Send()
        {
            try
            {
                this.smtpServer.Send(this.mail);
            }
            catch (Exception ex)
            {
                this.sendSuccess = false;
                this.sendError = ex.ToString();
            }
        }
    }
}
