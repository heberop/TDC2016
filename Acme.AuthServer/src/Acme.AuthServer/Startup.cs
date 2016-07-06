using Acme.AuthServer.Repo;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

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

            //services.AddIdentityServer()
            //        .SetSigningCredential(cert)
            //        .AddInMemoryClients(clients)
            //        .AddInMemoryScopes(scopes)
            //        .AddInMemoryUsers(users);

            services.AddIdentityServer()
                    .SetSigningCredential(cert);

            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IClientStore, ClientStore>();
            services.AddTransient<IScopeStore, ScopeStore>();

        }
        public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
        {
            public Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
            {
                throw new NotImplementedException();
            }
        }

        public class ProfileService : IProfileService
        {
            public Task GetProfileDataAsync(ProfileDataRequestContext context)
            {
                
                throw new NotImplementedException();
            }

            public Task IsActiveAsync(IsActiveContext context)
            {
                throw new NotImplementedException();
            }
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
