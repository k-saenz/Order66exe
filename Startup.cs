using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order66exe.Data;
using Order66exe.Models;
using Order66exe.Models.Services;
using System;

namespace Order66exe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Order66DbContext>(options =>
                options.UseSqlServer(
                    _config.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<DiscordUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Order66DbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //Add email config
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(_config);


            /***START AUTHENTICATION METHODS***/

            ///<summary>
            ///Authenticate the user on startup. These methods add third party authentication
            ///schemes to the app
            /// </summary>
            services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/AccessDenied";
                })
                .AddDiscord(options =>
                {
                    options.ClientId = _config.GetValue<string>("Authentication:Discord:ClientId");
                    options.ClientSecret = _config.GetValue<string>("Authentication:Discord:ClientSecret");
                    options.Scope.Add("identify");
                    options.Scope.Add("email");
                    options.AuthorizationEndpoint = "https://discord.com/api/oauth2/authorize";

                })
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuth = _config.GetSection("Authentication:Google");
                    options.ClientId = googleAuth["ClientId"];
                    options.ClientSecret = googleAuth["ClientSecret"];
                });
                
            /***END AUTHENTICATION METHODS***/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days
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
