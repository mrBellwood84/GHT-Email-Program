using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppLib.Collection
{
    public class GetPath
    {
        /** Calling members will return string with file path from program root
         *  Folder and file strings kept seperated to create folder if and when needed */

        // program root folder
        protected static readonly string root = Directory.GetCurrentDirectory();

        // folders
        protected static readonly string configFolder = "config";     // config folder
        protected static readonly string logFolder = "log";        // log folder

        // files
        protected static readonly string keysFile = ".keys";      // key file
        protected static readonly string configFile = ".conf";      // config file path in program root
        protected static readonly string logFile = ".log";       // log file path in program root

        public static string Keys { get => Path.Combine(root, configFolder, keysFile); }
        public static string Config { get => Path.Combine(root, configFolder, configFile); }

        public static string Log
        {
            get
            {
                string path = Path.Combine(root, logFolder);    // create path
                bool exist = Directory.Exists(path);           // check if folders exist
                if (!exist)
                {
                    Directory.CreateDirectory(path);            // create folders if not exist;
                }
                return Path.Combine(path, logFile);             // return path;
            }
        }
    }
}
