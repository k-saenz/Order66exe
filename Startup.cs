using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Order66exe.Data;
using Order66exe.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Order66exe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<DiscordUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            /***START AUTHENTICATION METHODS***/
            //Authenticate on Startup
            services.AddAuthentication(options =>
            {
                //Creates cookie so users stay logged in
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //When you get a token, make sure that this program created this token
                        //Issuer: Who Created the token
                        ValidateIssuer = false,
                        //Validate Frontend
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,

                        //Get data from appsettings.json
                        ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                        ValidAudience = Configuration.GetValue<string>("Jst:Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:EncryptionKey")))
                    };
                })
                //.AddOAuth("Discord",
                .AddDiscord(options =>
                    {
                        //Configure Discord related Login

                        //Where to authorize
                        options.AuthorizationEndpoint = "https://discord.com/api/oauth2/authorize";

                        //Identify scope returns user id without email and Guild info
                        options.Scope.Add("identify");
                        options.Scope.Add("guilds");
                        options.Scope.Add("guilds.members.read");

                        options.CallbackPath = new PathString("/auth/oauthCallback");

                        options.ClientId = Configuration.GetValue<string>("Discord:ClientId");
                        options.ClientSecret = Configuration.GetValue<string>("Discord:ClientSecret");

                        options.TokenEndpoint = "https://discord.com/api/oauth2/token";
                        

                        //Where to get info from
                        //Returns user object as JSON
                        options.UserInformationEndpoint = "https://discord.com/api/users/@me";
                        
                        //Returns Guild Member object as JSON with embedded User Object
                        //options.UserInformationEndpoint = "https://discord.com/api/guilds/688917645139116290/members/@me";

                        //Get stuff from JSON that was sent with user object
                        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
                        //options.ClaimActions.MapJsonKey("Roles", "roles");
                        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "discriminator");
                        options.ClaimActions.MapJsonKey(ClaimTypes.Hash, "avatar");

                        //If user couldn't be authenticated to refused to authenticate, it send to this page
                        options.AccessDeniedPath = "/Home/AuthFailed";

                        //After getting temp token, then ask for token, then ask for user info
                        options.Events = new OAuthEvents
                        {
                            OnCreatingTicket = async context =>
                            {
                                //Create Get request
                                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                                //Response we get after making the get request
                                //Send request with this var then it stores the response from Discord
                                var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                                response.EnsureSuccessStatusCode();

                                //Get the user from the response
                                var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;

                                context.RunClaimActions(user);
                            }
                        };
                    }
                );
            /***END AUTHENTICATION METHODS***/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
