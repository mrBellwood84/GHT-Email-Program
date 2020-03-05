using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using AppLib.Collection;

namespace AppLib.Email
{
    public class CreateEmailBody
    {
        /** Replace placeholders in mailTemplate with data.
         *  Contain method for creating a mail body string for sending mail
         *  Contain method for creating a html document for mail preveiw. 
         *  Preview method produce document and return path string to saved document.
         *  
         *  Template body is set when object is created.
         *  Reciver can be replaced for repeated production of mail bodies. */


        private EmailBodyTemplate template;
        private Reciver reciver;
        private string mailTempate;

        public EmailBodyTemplate Template { get => template; }
        public Reciver ReciverObj { get => reciver; set => reciver = value; }



        public CreateEmailBody(EmailBodyTemplate template)
        {
            this.template = template;

            string mailTemplatePath = GetPath.MailMarkup;
            this.mailTempate = File.ReadAllText(mailTemplatePath);
        }

        public string CreatePreview()
        {
            string language = reciver.Language;
            string body = populateMailTemplate(language);

            string imageElem = $"<img src=\"..\\Res\\Img\\headlogo.png\" width =\"400\" style=\"padding: 20px\">";

            body = body.Replace("{image}", imageElem);

            return body;
        }


        private string populateMailTemplate(string lang)
        {
            EmailBodyTemplate.Content content = new EmailBodyTemplate.Content();

            if (lang == "NO")
            {
                content = this.template.NO;
            }
            else
            {
                content = this.template.EN;
            }

            if(reciver.FullName == "")
            {
                reciver.FullName = content.GuestDefaultName;
            }

            string body = this.mailTempate.Replace("{GUEST_GREETING}", content.GuestGreeting)
                                          .Replace("{GUEST_NAME}", reciver.FullName)
                                          .Replace("{MAIL_TEXT}", content.MailText)
                                          .Replace("{SENDER_GREET}", content.SenderGreeting)
                                          .Replace("{SENDER_NAME}", content.SenderDefaultName);

            return body;
        }
    }
}
