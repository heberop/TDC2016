﻿using Acme.AuthServer.Repo;
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

            var clients = Clients.Get();
            
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
