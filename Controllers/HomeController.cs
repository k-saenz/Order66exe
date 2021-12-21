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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Order66exe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
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

        public IActionResult Login()
        {
            string redirectURI = _config.GetValue<string>("Discord:RedirectURI");
            return Redirect(redirectURI);
        }

        [Authorize(AuthenticationSchemes = "Discord")]
        public IActionResult Events()
        {

            return View();
        }

        [Authorize(AuthenticationSchemes = "Discord")]
        public async Task<IActionResult> Admin()
        {
            //Get ID and Username of legged in user
            var id = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var username = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;

            string requestUri = "https://discord.com/api/users/@me/guilds/688917645139116290/member";

            Console.WriteLine("id: " + id);
            Console.WriteLine("username: " + username);

            //Create Get request
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");


            //Response we get after making the get request
            //Send request with this var then it stores the response from Discord
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();

            string result = response.Content.ReadAsStringAsync().Result;

            //Get the user from the response
            var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;

            Console.WriteLine("JSON returned from API: " + result);

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
            catch (InvalidOperationException ex)
            {
                return "";
            }
        }
    }
}
