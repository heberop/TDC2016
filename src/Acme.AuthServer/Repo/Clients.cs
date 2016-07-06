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
                        "http://localhost:2000"
                    },

                    AllowedGrantTypes = GrantTypes.Implicit,

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
                        "http://localhost:3000"
                    },

                    AllowedGrantTypes = GrantTypes.Implicit,

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name
                    }
                },
            };
        }
    }
}
