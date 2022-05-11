using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Order66exe.Models.Services
{
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }
        private readonly string _emailApiKey;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
            _emailApiKey = Options.SendGridKey;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(_emailApiKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(_emailApiKey, email, subject, htmlMessage);
        }

        private async Task Execute(string apiKey, string email, string subject, string message)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@order66exe.com", "Order_66.exe"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            //Disable Click tracking
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
