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
        protected static readonly string configFolder = "Config";           // config folder
        protected static readonly string logFolder = "Log";                 // log folder
        protected static readonly string templatesFolder = "Templates";     // temlates folder
        protected static readonly string savedListFolder = "Saved";         // saved lists
        protected static readonly string previewFolder = "Preview";         // temporary files
        protected static readonly string resourceFolder = "Res";            // resource folder

        // files
        protected static readonly string keysFile = ".keys";                // key file
        protected static readonly string configFile = ".conf";              // config file path in program root
        protected static readonly string logFile = ".log";                  // log file path in program root
        protected static readonly string mailmarkup = "mailTemplate.html";  // mail markup file


        // existing folder and files
        public static string Keys { get => Path.Combine(root, configFolder, keysFile); }
        public static string Config { get => Path.Combine(root, configFolder, configFile); }
        public static string MailMarkup { get => Path.Combine(root, resourceFolder, mailmarkup); }
        public static string Resources { get => Path.Combine(root, resourceFolder); }


        // create if not exist folders
        public static string SaveListFolder
        {
            get
            {
                string path = Path.Combine(root, savedListFolder);  // get path
                bool exist = Directory.Exists(path);                // check if path exist
                if (!exist)                                         // if path dont exist
                {   
                    Directory.CreateDirectory(path);                // create path
                }
                return path;                                        // return path
            }
        }

        public static string PreviewFolder
        {
            get
            {
                string path = Path.Combine(root, previewFolder);    // get path
                bool exist = Directory.Exists(path);                // check if path exist
                if (!exist)                                         // if path dont exist
                {
                    Directory.CreateDirectory(path);                // create path
                }
                return path;                                        // return path
            }
        }

        public static string TemplateFolder
        {
            get
            {
                string path = Path.Combine(root, templatesFolder);  // get path
                bool exist = Directory.Exists(path);                // check if path exist
                if (!exist)                                         // if path dont exist
                {
                    Directory.CreateDirectory(path);                // create path
                }
                return path;                                        // return path
            }
        }

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
