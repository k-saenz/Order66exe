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
        private readonly string _emailApiKey = "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";
        //private readonly string _emailApiKey = Environment.GetEnvironmentVariable("ORDER66EXE_SERVICES_EMAIL_API_KEY");

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(_emailApiKey, email, subject, htmlMessage);
        }

        public async Task Execute(string apiKey, string subject, string message, string htmlMessage)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@order66exe.com", "Test Email - String set in EnailSender.Execute"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(htmlMessage));

            //Disable Click tracking
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }

        public async Task Go()
        {
            var client = new SendGridClient(_emailApiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
