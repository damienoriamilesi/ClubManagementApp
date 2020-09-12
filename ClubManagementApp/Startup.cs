using ClubManagementApp.Infrastructure;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ClubManagementApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // Reset the claim mapping dictionary => the original claim types are kept
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ClubManagementDb");
            services.AddHttpContextAccessor();
            services.AddDbContext<ClubManagementContext>
                (cfg =>
                    cfg.UseSqlServer(connectionString, options => options.CommandTimeout(100).EnableRetryOnFailure(3))
                );

            services.AddControllers()
                     .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddHttpClient("IDPClient", client => 
            {
                client.BaseAddress = new System.Uri("https://localhost:44318/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //   .AddIdentityServerAuthentication(options =>
            //   {
            //       options.ApiName = "imagegalleryapi";
            //       options.Authority = "https://localhost:44318";
            //       options.ApiSecret = "apisecret"; // used by reference token instead of self contained JWT
            //    });

            // TODO > Move to an MVC Web app client
            #region TODO > Move to an MVC Web app client
            services
                .AddAuthentication(cfg =>
                {
                    cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    // Redirect to custom error page
                    //options.AccessDeniedPath = "/Authorization/AccessDenied";
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                })
                //.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                //{
                //    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //    options.Authority = "https://localhost:44318/";
                //    options.ClientId = "imagegalleryapi"; //TODO > To get from external config
                //    options.ResponseType = "code";
                //    options.UsePkce = true; //=> Applied for APIs
                //    ////options.CallbackPath = new PathString("/toto"); // The redirectUri specified in the IdentityServer Config (http://localhost:44363/signin-oidc)

                //    //Add scopes to ClaimsIdentity
                //    //options.Scope.Add("openid");
                //    //options.Scope.Add("profile");
                //    options.Scope.Add("address");
                //    options.Scope.Add("roles");

                //    //options.Scope.Add("imagegalleryclientapi");

                //    //// Remove a property from ClaimsIdentity => cookie smaller
                //    options.ClaimActions.DeleteClaim("sid");
                //    options.ClaimActions.DeleteClaim("idp");
                //    options.ClaimActions.DeleteClaim("s_hash");
                //    options.ClaimActions.DeleteClaim("auth_time");
                //    //options.ClaimActions.DeleteClaim("address");

                //    // Add properties to ClaimsIdentity
                //    options.ClaimActions.MapUniqueJsonKey("address", "address");
                //    options.ClaimActions.MapUniqueJsonKey("role", "role");

                //    options.SaveTokens = true;
                //    options.ClientSecret = "apisecret"; //TODO > To get from external config => equals secret configured into IdentityServer Configs
                //    options.GetClaimsFromUserInfoEndpoint = true;
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        NameClaimType = JwtClaimTypes.GivenName,
                //        RoleClaimType = JwtClaimTypes.Role
                //    };
                //})
                .AddOpenIdConnect(options =>
                {
                    options.UsePkce = true;
                    options.ClientId = Configuration["okta:ClientId"];
                    options.ClientSecret = Configuration["okta:ClientSecret"];
                    options.Authority = Configuration["okta:Issuer"];
                    options.CallbackPath = "/authorization-code/callback";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.UseTokenLifetime = false;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name"
                    };
                });
            ;
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ClubManagementContext>();
                    context.Database.EnsureCreated();
                }
            }

            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}