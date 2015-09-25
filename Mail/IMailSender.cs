using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mail
{
    public interface IMailSender
    {
        EmailStatus Send(EmailMessage email);
    }

    public class EmailMessage
    {
        public string Subject { get;private set; }
        public EmailAddress Sender { get; private set; }
        public EmailAddress Recipient { get; private set; }
        public List<EmailAddress> CC { get; private set; }
        public List<EmailAddress> CCO { get; private set; }
        public List<EmailAttachment> Attachments { get; private set; }
        public string ContentMessage { get; private set; }
        public bool IsHtmlMessage { get; private set; }
        public EmailStatus Status { get; private set; }
        public string StatusMessage { get;private set; }

        public EmailMessage(string subject, EmailAddress recipient, string content, bool isHtml)
        {
            this.Status = EmailStatus.Waiting;
            this.Subject = subject;
            this.Recipient = recipient;
            this.ContentMessage = content;
            this.IsHtmlMessage = isHtml;
            this.CC = new List<EmailAddress>();
            this.CCO = new List<EmailAddress>();
            this.Attachments = new List<EmailAttachment>();
        }

        public void Send(IMailSender sender)
        {
            this.Status = sender.Send(this);
        }
        public void SetStatusMessage(string message)
        {
            this.StatusMessage = message;
        }
    }

    public enum EmailStatus
    {
        Waiting = 1, Sent = 2, Fail = 3
    }

    public class EmailAddress
    {
        private string expressao = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public string Email { get; private set; }

        public EmailAddress(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                Validar(email);
            this.Email = email;
        }
        public bool HasValue()
        {
            return !string.IsNullOrWhiteSpace(this.Email);
        }
        private void Validar(string email)
        {
            if (HasValue())
                throw new Exception("E-mail inválido.");

            if (!Regex.IsMatch(email, expressao, RegexOptions.IgnoreCase))
                throw new Exception("E-mail inválido.");
        }
    }

    public class EmailAttachment
    {
        public string Name { get; set; }

        public byte[] File{ get; set; }

        public EmailAttachment(string name, byte[] file)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new Exception("Informe o nome do arquivo anexo");

            if(file== null)
                throw new Exception("Informe o arquivo anexo");

            this.Name = name;
            this.File = file;
        }
    }
}
