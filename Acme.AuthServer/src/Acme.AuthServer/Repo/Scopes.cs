using IdentityServer4.Models;
using System.Collections.Generic;

namespace Acme.AuthServer.Repo
{
    public class Scopes
    {
        public static IList<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile
            };
        }
    }
}
