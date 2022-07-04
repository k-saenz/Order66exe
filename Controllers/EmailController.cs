using Microsoft.AspNetCore.Mvc;
using Order66exe.Models.Services;
using System.Net.Mail;

namespace Order66exe.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirm(EmailModel s)
        {
            var email = new MailMessage();
            email.To.Add(s.To);
            email.Subject = s.Subject;
            email.Body = s.Body;
            email.From = new MailAddress(s.From);


            return View();
        }
    }
}
