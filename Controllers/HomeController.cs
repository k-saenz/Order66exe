using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order66exe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Discord.WebSocket;

namespace Order66exe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<DiscordUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<DiscordUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View(new List<SocketRole>());
        }

        [Authorize(AuthenticationSchemes = "Discord")]
        public IActionResult Events()
        {

            return View();
        }

        public IActionResult AuthFailed()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
