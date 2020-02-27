using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AppLib.Email
{
    public class Reciver
    {
        /** Handle all data specific for reciver of email 
         *  Only basic data per now, but can be expanded     */

        private string _id;
        private string name;
        private string email;
        private bool send = true;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get
            {
                if (name == null)
                {
                    return "Navn mangler";
                }
                else
                {
                    return name;
                }
            }
            set { name = value; }
        }

        public string Email
        {
            get 
            {
                if (email == null)
                {
                    return ("Epost mangler");
                }
                else
                {
                    return email;
                }

            }
            set { name = value; }
        }

        public bool Send
        {
            get { return send; }
            set { send = value; }
        }

        // defult constructor return empty object
        public Reciver()
        {

        }

        // second constructor for basic information
        public Reciver(string name, string email)
        {
            this.name = name;
            this.email = email;
        }
    }
}
