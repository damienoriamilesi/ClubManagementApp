// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Company.IDP
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();
            var identityServerStoreDatabaseConnectionString
                = "Server=LAPDORIA;Database=ClubManagementIdp;Trusted_connection=True;";

            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddTestUsers(TestUsers.Users);

            services.AddAuthentication()
                .AddFacebook("Facebook", opt =>
                {
                    opt.AppId = " ";
                    opt.AppSecret = " ";
                    opt.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                });
                ////https://console.developers.google.com/
                //.AddGoogle("Google", opt =>
                //{
                //    opt.ClientId = "309924201256-jklbmtk3g9vvkijjo1jhv6n5vf4p7hs3.apps.googleusercontent.com";
                //    opt.ClientSecret = "SE_2NO1ZlegOqf_r1ipal93V";
                //    opt.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                //})

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
