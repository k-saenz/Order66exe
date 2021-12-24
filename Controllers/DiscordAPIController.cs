using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order66exe.Controllers
{
    //Use this API controller to hold data needed for app
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordAPIController : ControllerBase
    {
        [HttpGet("owner")]
        public object GetOwner()
        {
            //returns anonymous object
            //Automatically is returned as JSON
            return new
            {
                Owner = "Some guy",
                Server = "Their server"
            };
        }



    }
}
