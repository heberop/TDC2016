using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Acme.AuthServer
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            _environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //DÊ SEMPRE PREFERÊNCIA POR UM CERTIFICADO REGISTRADO NA MAQUINA
            var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsrv3test.pfx"), "idsrv3test");

            var clients = new List<Client>
            {
                new Client
                {
                    ClientName = "ACME Fabrica",
                    ClientId = "Acme.Fabrica",

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
