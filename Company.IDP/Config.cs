// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Company.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "Your role(s)", new string[]{ "role" })
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("imagegalleryapi", "Image Gallery API")
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope()
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   new Client
                   {
                       ClientName = "Image Gallery",
                       ClientId = "imagegalleryapi",
                       AllowedGrantTypes = GrantTypes.Code,
                       RequirePkce = true,
                       RedirectUris = new List<string>{
                           "https://localhost:5001/signin-oidc"
                       },
                       AllowedScopes =
                       {
                           IdentityServerConstants.StandardScopes.OpenId
                           , IdentityServerConstants.StandardScopes.Profile
                           , IdentityServerConstants.StandardScopes.Address
                           , "roles"
                           //, "roles"
                           //, "imagegalleryapi"
                       },
                       ClientSecrets = { new Secret("apisecret".Sha256()) }
                   }
            };
    }
}