using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppLib.Collection
{
    public class Templates
    {

        public static string[] Paths { get => getTemplatePaths(); }

        private static string[] getTemplatePaths()
        {
            string templateFolder = GetPath.TemplatesFolder;
            
            if (!Directory.Exists(templateFolder))
            {
                return new string[] { };
            }
            else
            {
                return Directory.GetFiles(templateFolder);
            }
            
        }
    }
}
