using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
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

            string imageElem = $"..\\Res\\Img\\headlogo.png";

            body = body.Replace("{image}", imageElem);

            return body;
        }

        public MailMessage CreateMail(string senderEmail, string subject)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.AlternateViews.Add(createMailView());
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(reciver.Email);
            mail.Subject = subject;
            return mail;
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

        private AlternateView createMailView()
        {
            // create mail body
            string language = reciver.Language;
            string mailBody = populateMailTemplate(language);

            // get image resource
            string imagePath = Path.Combine(GetPath.Resources, "Img", "headlogo.png");
            LinkedResource res = new LinkedResource(imagePath);
            res.ContentId = Guid.NewGuid().ToString();

            // append image to mail body
            mailBody = mailBody.Replace("{image}", $"cid:'{res.ContentId}'");

            // create alternative view object
            AlternateView view = AlternateView.CreateAlternateViewFromString(mailBody);
            view.LinkedResources.Add(res);

            // return produced object
            return view;
        }
    }
}
