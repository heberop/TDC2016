﻿using Acme.AuthServer.Repo;
using Acme.AuthServer.UI;
using Acme.AuthServer.UI.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            var clients = Clients.Get();

            var scopes = Scopes.Get();

            var users = Users.Get();

            services.AddIdentityServer()
                    .SetSigningCredential(cert)
                    .AddInMemoryClients(clients)
                    .AddInMemoryScopes(scopes)
                    .AddInMemoryUsers(users);

            services.AddMvc()
                    .AddRazorOptions(razor =>
                    {
                        razor.ViewLocationExpanders.Add(new CustomViewLocationExpander());
                    });

            services.AddTransient<LoginService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
