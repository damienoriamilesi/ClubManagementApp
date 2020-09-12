using System;
using System.Collections.Generic;
using System.Linq;
using ClubManagementApp.Infrastructure;
using ClubManagementApp.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Net.Http;
using IdentityModel.Client;

namespace ClubManagementApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ClubManagementContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClubController(ClubManagementContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        //[Authorize(Roles = "AllowedUser")]
        //[Authorize(Policy = "SomePolicy")] => TODO > register policy in startup
        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Club>> Get()
        {
            //await WriteOutIdentityInformation();

            return _context.Clubs.ToList();
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetById")]
        public Club GetById(Guid id)
        {
            var newClub = new Club { Code = "740000001", Name = "NewClub" };
            //newClub.Id = Guid.NewGuid();
            return newClub;
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddNewClub(Club club)
        {
            return CreatedAtRoute(nameof(GetById), new { id = club.Id.ToString() }, club);
        }

        [HttpGet]
        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        private async Task WriteOutIdentityInformation()
        {
            var idp = _httpClientFactory.CreateClient("IDPClient");

            var metadateResponse = await idp.GetDiscoveryDocumentAsync();

            if (metadateResponse.IsError)
                throw new Exception("Pb accessing Discovery endpoint.", metadateResponse.Exception);

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userInfoReponse = await idp.GetUserInfoAsync(new UserInfoRequest { Address = metadateResponse.UserInfoEndpoint, Token = accessToken });
            //if (userInfoReponse.IsError)
            //    throw new Exception("Pb accessing UserInfo endpoint.", metadateResponse.Exception);


            //Debug.WriteLine("Claims address : " + userInfoReponse.Claims.FirstOrDefault(x => x.Type == "address")?.Value);

            //var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            //Debug.WriteLine($"IdentityToken : {identityToken}");

            foreach(var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type : {claim.Type} - Claim value : {claim.Value}");
            }
        }
    }
}
