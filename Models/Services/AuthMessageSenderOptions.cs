using System;

namespace Order66exe.Models.Services
{
    public class AuthMessageSenderOptions
    {

        public string? SendGridKey
        {
            get
            {
                return "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";
                //return Environment.GetEnvironmentVariable("ORDER66EXE_SERVICES_EMAIL_API_KEY");
            }
        }
    }
}
