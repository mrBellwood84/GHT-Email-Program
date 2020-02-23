using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// own lib namespaces here
using AppLib;
using AppLib.Collection;
using AppLib.Secrets;

namespace EmailGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // string keyPaht = GetPath.Keys;      // get key path
            // CreateKeyFile createKey = new CreateKeyFile(2020, 07, 31);      // delete this before production or not needed
            // createKey.WriteKeyFile(keyPaht);                                // delete this before production or not needed

            KeyFile keyFile = new KeyFile();    // get keyfile content
            App.Key = keyFile;

            InitializeComponent();

            LoadByValidKey(keyFile);    // load page dependent on keyFile
        }


        public void LoadByValidKey(KeyFile keyFileInput)
        {
            /** Load page dependend on valid key file */

            VerifyKeyFile verifyKey = new VerifyKeyFile(keyFileInput);  // verify key
            
            if (!verifyKey.KeyFileValid)    // if keyfile not valid
            {
                // load invalid screen, boolean argument for expired key file
                Main.Content = new Frames.MainKeyInvalid(verifyKey.DateExpired);
            }
            else
            {
                Main.Content = new Frames.MainKeyValid();
            }

        }

    }
}
