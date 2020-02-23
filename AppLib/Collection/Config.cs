using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppLib.Collection
{
    public class ConfigFile
    {
        /** contain data for smtp server
         *  Default constructor get data from stored config file
         *  Second constructor for creating a new ConfigFile with new data */

        private string smtpServer;
        private string username;
        private string password;
        private int port;
        private bool ssl;
        private string senderEmail;
        private int contentCount;

        private string filePath = Collection.GetPath.Config;

        public string SmtpServer { get => smtpServer; }
        public string UserName { get => username; }
        public string Password { get => password; }
        public int Port { get => port; }
        public bool SSL { get => ssl; }
        public string SenderEmail { get => senderEmail; }
        public int ContentCount { get => contentCount; }

        public ConfigFile(bool setContent = true)
        {
            string[] content = LoadConfigFile();    // get config file content

            if (setContent)
            {
                int len = content.Length;               // get array length
                Secrets.Encryptor encryptor = new Secrets.Encryptor();

                for (int i = 1; i < len; i++)       // decrypt array content
                {
                    content[i] = encryptor.Decrypt(content[i]);
                }

                this.smtpServer = content[1];
                this.username = content[2];
                this.password = content[3];
                this.port = Convert.ToInt32(content[4]);
                this.ssl = Convert.ToBoolean(content[5]);
                this.senderEmail = content[6];
            }
            else
            {
                this.contentCount = content.Length;
            }
        }


        public ConfigFile(string server, string user, string pass, int port, bool ssl, string senderEmail)
        {
            this.smtpServer = server;
            this.username = user;
            this.password = pass;
            this.port = port;
            this.ssl = ssl;
            this.senderEmail = senderEmail;
        }

        public void SaveConfigFile()
        {
            Secrets.Encryptor encryptor = new Secrets.Encryptor();  // create encryptor object
            string[] result = new string[]  {   PasswordHash(),     // append all properties to an array;
                                                this.smtpServer,
                                                this.username,
                                                this.password,
                                                this.port.ToString(),
                                                this.ssl.ToString(),
                                                this.senderEmail
                                            };
            int len = result.Length;        // get array length
            for (int i = 1; i < len; i++)   // loop all items exept first
            {
                result[i] = encryptor.Encrypt(result[i]);   // encrypt items
            }

            File.WriteAllLines(this.filePath, result);      // overwrite file
            
        }

        private string[] LoadConfigFile()
        {
            string[] content = File.ReadAllLines(this.filePath);    // get content
            return content;                                         // return array
        }

        public static void CreateNewConfigFile(string passwordHashed)
        {
            string path = GetPath.Config;
            File.WriteAllText(path,passwordHashed);
        }

        public static string PasswordHash()
        {
            string path = GetPath.Config;
            string[] lines = File.ReadAllLines(path);
            return lines[0];
        }
    }
}
