using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AppLib
{
    public class Logger
    {
        private static string logFilePath   = Collection.GetPath.Log;
        private static string[] errorTypes = new string[] { "KEYFILE_ERROR" };

        public static void AppendLogEntry(string errorType, string message)
        {
            if (Array.IndexOf(errorTypes, errorType) == -1)
            {
                errorType = "UKNOWN_ERROR";
            }

            string timestamp = DateTime.Now.ToString("MM/dd/yyyy-HH:mm:ss").Replace(" ", "");
            string logEntry = $"[{timestamp}] {errorType}: \"{message}\"\n";
            Console.WriteLine(logEntry);
            File.AppendAllTextAsync(logFilePath, logEntry);
        }
    }
}
