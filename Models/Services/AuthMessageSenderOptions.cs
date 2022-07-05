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
                return "";
                //return Environment.GetEnvironmentVariable("ORDER66EXE_SERVICES_EMAIL_API_KEY");
            }
        }
    }
}
