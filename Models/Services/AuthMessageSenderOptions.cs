#nullable enable
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
