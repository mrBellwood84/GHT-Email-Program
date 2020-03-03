using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using AppLib.Collection;

namespace AppLib.Email
{
    public class Reciver
    {
        /** Handle all data specific for reciver of email 
         *  Only basic data for now, but can be expanded     */


        private string fullName;
        private string email;
        private string language;

        public string FullName
        {
            get
            {
                if ((fullName == null))
                {
                    return "";
                }
                else
                {
                    return fullName;
                }
            }
            set
            {
                fullName = FormatString.Name(value);
            }
        }

        public string Email
        {
            get
            {
                if ((email == null) || (email == ""))
                {
                    return "EPOST MANGLER";
                }
                else
                {
                    return email;
                }
            }
            set
            {
                email = value;
            }
        }

        public string Language
        {
            get
            {
                if (language == "" || language == null)
                {
                    return "EN";
                }
                else
                {
                    return language;
                }
            }
            set
            {
                string[] valid = new string[] { "EN", "NO" };
                int index = Array.IndexOf(valid, value.ToUpper());
                if (index == -1)
                {
                    language = "EN";
                }
                else
                {
                    language = value.ToUpper();
                }
                  
            }

        }

        public Reciver()
        {
            // default return empty object
        }

        public Reciver(string fullName, string email)
        {
            this.fullName = FormatString.Name(fullName);
            this.email = email;
        }
    }
}
