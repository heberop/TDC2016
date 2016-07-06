using IdentityModel;
using IdentityServer4.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace Acme.AuthServer.Repo
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "1234",
                    Username = "patolino",
                    Password = "P@ssw0rd",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Patolino"),
                        new Claim(JwtClaimTypes.Email, "patolino@acme.com")
                    }
                }
            };
        }
    }
}
