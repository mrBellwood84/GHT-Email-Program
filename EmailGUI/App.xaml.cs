using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

// own libs
using AppLib.Collection;
using AppLib.Secrets;
using AppLib.Email;

namespace EmailGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static KeyFile Key { get; set; }
        public static bool ConfigFileExist
        {
            get => checkConfigFile();
        }
        private static bool checkConfigFile()
        {
            string path = GetPath.Config;
            return File.Exists(path);
        }


        public static List<Reciver> Recivers = new List<Reciver>();
        public static int ReciverFileAdded = 0;
        public static int ReciverUserAdded = 0;
    }

}
