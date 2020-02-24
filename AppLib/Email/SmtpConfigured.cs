using System;
using System.Net.Mail;

using AppLib.Collection;

namespace AppLib.Email
{
    public class SmtpConfigured
    {
        /** Returns a SmtpClient object configured with specification from config file */

        private bool validConfig;           // boolean for valid config file
        private bool buildSuccess = true;   // confirm if object was created without exeptions
        private SmtpClient server;          // server object

        public bool ValidConfigFile { get => validConfig; } // get bool to check before using
        public bool BuildSuccess { get => buildSuccess; }   // get bool to check before using
        public SmtpClient Server { get => server; }         // get server;


        public SmtpConfigured()
        {
            ConfigFile configFile = new ConfigFile();           // get config file
            this.validConfig = (configFile.ContentCount > 1);   // validate config file, check if it got all needed values

            if (this.validConfig)                               // of config file is okey
            {
                SmtpClient client = new SmtpClient(configFile.SmtpServer);  // create smtp object
                try
                {
                    client.Port = configFile.Port;                          // assign values to smtp object from config file
                    client.EnableSsl = configFile.SSL;
                    client.Credentials = new System.Net.NetworkCredential(configFile.UserName, configFile.Password);
                }
                catch (Exception ex)                                        // catch exceptions
                {
                    this.buildSuccess = false;                              // set buildsuccess to false
                    Logger.AppendLogEntry("SMTP_ERROR", ex.ToString());     // log error to log file
                }
                this.server = client;                                       // set smtp object

            }

            
        }

    }
}
