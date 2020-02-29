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
        private bool send = true;

        public string FullName
        {
            get
            {
                if ((fullName == null) || (fullName == ""))
                {
                    return "NAVN MANGLER";
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

        public bool Send
        {
            get => send;
            set => send = value;
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
