//namespace Order66exe
//{
//    public class backup
//    {
//        .AddDiscord(async options =>
//                {
//            ///<summary>
//            ///Configure Discord third party login
//            ///</summary>

//            ///<remarks>
//            ///Identify what scopes for API to return
//            ///</remarks>
//            options.Scope.Add("identify");
//            options.Scope.Add("email");
//            options.Scope.Add("guilds");
//            options.Scope.Add("guilds.members.read");

//            options.CallbackPath = new PathString("/auth/oauthCallback");

//            ///<remarks>
//            ///Get Client ID and Client Secret from JSON section in configuration files
//            ///</remarks>
//            IConfigurationSection discordAuthSection = Configuration.GetSection("Authentication:Discord");
//            options.ClientId = discordAuthSection["ClientId"];
//            options.ClientSecret = discordAuthSection["ClientSecret"];

//            ///<remarks>
//            ///Configure enpoints
//            ///</remarks>
//            options.AuthorizationEndpoint = "https://discord.com/api/oauth2/authorize";
//            options.TokenEndpoint = "https://discord.com/api/oauth2/token";
//            options.UserInformationEndpoint = "https://discord.com/api/users/@me";

//            ///<remarks>
//            ///Get information from JSON file recieved from Discord along with user object
//            ///</remarks>
//            options.ClaimActions.MapJsonKey(ClaimTypes.PrimarySid, "id");
//            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
//            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "discriminator");
//            options.ClaimActions.MapJsonKey("AvatarHash", "avatar");
//            options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

//            ///<remarks>
//            ///If user couldn't be authenticated or refused to authenticate, it redirects
//            ///to this page before returning to home page
//            ///</remarks>
//            options.AccessDeniedPath = "/Home/AuthFailed";

//            ///<remarks>
//            ///After getting the temp token, ask for token then for user info
//            ///</remarks>
//            //options.Events = new OAuthEvents
//            //{
//            //    OnCreatingTicket = async context =>
//            //    {
//            //        ///<remarks>
//            //        ///Create Get Request to be sent to Discord OAuth
//            //        ///</remarks>
//            //        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
//            //        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

//            //        ///<remarks>
//            //        ///Response after making the get request. This variable sends the request
//            //        ///and stores the response from Discord. After that, we ensure the request was successful
//            //        ///and get the user from the response by parsing the JSON response. Once we have the user, 
//            //        ///we can run the previously specified Claim Actions on it
//            //        ///</remarks>
//            //        var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
//            //        response.EnsureSuccessStatusCode();

//            //        var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
//            //        context.RunClaimActions(user);

//            //    }
//            //};
//        });
//    }
//}
