using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mail.Gmail
{
    public class ISenderGmail : IMailSender
    {
        public EmailStatus Send(EmailMessage email)
        {
            EmailStatus status = email.Status;
            try
            {
                string emailSender = System.Configuration.ConfigurationManager.AppSettings.Get("email");
                string emailpassword = System.Configuration.ConfigurationManager.AppSettings.Get("emailpassword");
                string notification =System.Configuration.ConfigurationManager.AppSettings.Get("notification");
                string smtp = System.Configuration.ConfigurationManager.AppSettings.Get("smtp");
                int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("port"));
                bool enableSSL = bool.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("enableSSL"));


                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(emailSender);
                msg.Subject = email.Subject;
                msg.To.Add(email.Recipient.Email);

                //confimacao de leitura
                msg.Headers.Add("Disposition-Notification-To", emailSender);

                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure |
                                                  DeliveryNotificationOptions.OnSuccess |
                                                  DeliveryNotificationOptions.Delay;


                foreach (var item in email.CC)
                    msg.CC.Add(item.Email);

                foreach (var item in email.CCO)
                    msg.Bcc.Add(item.Email);

                msg.Body = email.ContentMessage;
                msg.IsBodyHtml = email.IsHtmlMessage;

                SmtpClient emailClient = new SmtpClient(smtp);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(emailSender, emailpassword);
                emailClient.UseDefaultCredentials = false;


                emailClient.Credentials = SMTPUserInfo;
                emailClient.Port = port;
                emailClient.EnableSsl = enableSSL;

                foreach (var item in email.Attachments)
                {
                    Attachment attach = new Attachment(new MemoryStream(item.File), item.Name);
                    msg.Attachments.Add(attach);
                }

                emailClient.Send(msg);

                status = EmailStatus.Sent;
            }
            catch (Exception ex)
            {
                email.SetStatusMessage(ex.Message);
                status = EmailStatus.Fail;
            }

            return status;
        }
    }
}
