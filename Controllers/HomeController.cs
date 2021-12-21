using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order66exe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Rest;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Order66exe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            //ViewBag.Username = GetUserName();
            return View();
        }

        public IActionResult Info()
        {
            return View();
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

        public string GetUserName()
        {
            //var id = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            try
            {
                var username = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
                var discriminator = User.Claims.First(c => c.Type == "discriminator").Value;

                return username + " #" + discriminator;

            }
            catch(InvalidOperationException ex)
            {
                return "";
            }
        }
    }
}
