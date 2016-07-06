using IdentityServer4.Models;
using System.Collections.Generic;

namespace Acme.AuthServer.Repo
{
    public class Clients
    {
        public static IList<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "ACME Backoffice",
                    ClientId = "Acme.Backoffice",

                    RedirectUris = new List<string>
                    {
                        "http://localhost:2000/signin-oidc"
                    },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name
                    }
                },

                new Client
                {
                    ClientName = "ACME Loja",
                    ClientId = "Acme.Loja",

                    RedirectUris = new List<string>
                    {
                        "http://localhost:3000/signin-oidc"
                    },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name
                    }
                },

                new Client
                {
                    ClientName = "ACME Fabrica",
                    ClientId = "Acme.Fabrica",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("segredo-muito-secreto".Sha256())
                    },

                    RedirectUris = new List<string>
                    {
                        "http://localhost:4000/signin-oidc"
                    },

                    AllowedGrantTypes = GrantTypes.Code,

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        "ApiProdutos"
                    }
                },

            };
        }
    }
}
