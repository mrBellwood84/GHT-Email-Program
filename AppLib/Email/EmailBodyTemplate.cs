using System;
using System.Collections.Generic;
using System.Text;

using AppLib.Collection;

namespace AppLib.Email
{
    public class EmailBodyTemplate
    {
        /** Hold content for email body construction
         *  Each string value is set as array for different language capacity.  */

        public NorwegianContent NO = new NorwegianContent();
        public EnglishContent EN = new EnglishContent();
        
        // empty default constructor
        public EmailBodyTemplate()
        {

        }

        public class EnglishContent
        {
            private string guestGreeting;
            private string guestDefaultName;
            private string senderGreeting;
            private string senderDefaultName;
            private string mailText;

            public string GuestGreeting 
            { 
                get => guestGreeting; 
                set => guestGreeting = FormatString.Text(value, false); 
            }
            public string GuestDefaultName
            {
                get => guestDefaultName;
                set => guestDefaultName = FormatString.Name(value);
            }
            public string SenderGreeting
            {
                get => senderGreeting;
                set => senderGreeting = FormatString.Text(value, false);
            }
            public string SenderDefaultName
            {
                get => senderDefaultName;
                set => senderDefaultName = FormatString.Name(value);
            }
            public string MailText
            {
                get => mailText;
                set => mailText = FormatString.Text(value);
            }
            
        }

        public class NorwegianContent : EnglishContent
        {

        }
    }
}
