using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AppLib
{
    public class Logger
    {
        private static string logFilePath   = Collection.GetPath.Log;

        public static void AppendLogEntry(string errorType, string message)
        {

            string timestamp = DateTime.Now.ToString("MM/dd/yyyy-HH:mm:ss").Replace(" ", "");
            string logEntry = $"[{timestamp}] {errorType}: \"{message}\"\n";
            File.AppendAllTextAsync(logFilePath, logEntry);
        }
    }
}
