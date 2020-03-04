using System;
using System.Collections.Generic;
using System.Text;

using AppLib.Collection;

namespace AppLib.Email
{
    public class EmailBodyTemplate
    {
        /** Hold content for email body construction
         *  Each string value is set as array for different language capacity.
         *  
         *  index 0: english
         *  index 1: norwegian  */


        private string[] guestGreeting;
        private string[] defaultGuestName;
        private string[] senderGreeting;
        private string[] defaultSenderName;
        private string[] message;

        public string[] GuestGreeting
        {
            get
            {
                return guestGreeting;
            }
            set
            {
                guestGreeting = setGreeting(value);
            }
        }
        public string[] DefaultGuestName
        {
            get
            {
                return defaultGuestName;
            }
            set
            {
                defaultGuestName = setName(value);
            }
        }
        public string[] SenderGreeting
        {
            get
            {
                return senderGreeting;
            }
            set
            {
                senderGreeting = setGreeting(value);
            }
        }
        public string[] DefaultSenderName
        {
            get
            {
                return defaultSenderName;
            }
            set
            {
                defaultSenderName = setName(value);
            }
        }
        public string[] MailMessage
        {
            get => message;
            set
            {
                message = setMail(value);
            }
        }


        
        // empty default constructor
        public EmailBodyTemplate()
        {

        }



        /** methods for class **/

        // for setting greeting with caplitalize first word
        public string[] setGreeting(string[] greetingArray)
        {
            string en  = FormatString.Text(greetingArray[0], false);
            string no = FormatString.Text(greetingArray[1], false);
            return new string[] { en, no };
        }

        // method overloaded to take two sepearte strings rather than an array
        public string[] setGreeting(string en, string no)
        {
            en = FormatString.Text(en, false);
            no = FormatString.Text(no, false);
            return new string[] { en, no };
        }


        // for setting capitalized name
        public string[] setName(string[] nameArray)
        {
            string en = FormatString.Name(nameArray[0]);
            string no = FormatString.Name(nameArray[1]);
            return new string[] { en, no };
        }

        // method overloaded to take two sepearte strings rather than an array
        public string[] setName(string en, string no)
        {
            en = FormatString.Name(en);
            no = FormatString.Name(no);
            return new string[] { en, no };
        }


        // for setting mail message
        public string[] setMail(string[] messageArray)
        {
            string en = FormatString.Text(messageArray[0]);
            string no = FormatString.Text(messageArray[1]);
            return new string[] { en, no };
        }

        // method overloaded to take two sepearte strings rather than an array
        public string[] setMail(string en, string no)
        {
            en = FormatString.Text(en);
            no = FormatString.Text(no);
            return new string[] { en, no };
        }
    }
}
