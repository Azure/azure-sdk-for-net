// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Azure.Samples
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        #region Snippet:ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            // Registering policy to use in ConfigureDefaults later
            services.AddSingleton<DependencyInjectionEnabledPolicy>();

            services.AddAzureClients(builder => {
                // Register blob service client and initialize it using the KeyVault section of configuration
                builder.AddSecretClient(Configuration.GetSection("KeyVault"))
                    // Set the name for this client registration
                    .WithName("NamedBlobClient")
                    // Set the credential for this client registration
                    .WithCredential(new ClientSecretCredential("<tenant_id>", "<client_id>", "<client_secret>"))
                    // Configure the client options
                    .ConfigureOptions(options => options.Retry.MaxRetries = 10);

                // Adds a secret client using the provided endpoint and default credential set later
                builder.AddSecretClient(new Uri("http://my.keyvault.com"));

                // Configures environment credential to be used by default for all clients that require TokenCredential
                // and doesn't override it on per registration level
                builder.UseCredential(new EnvironmentCredential());

                // This would use configuration for auth and client settings
                builder.ConfigureDefaults(Configuration.GetSection("Default"));

                // Configure global retry mode
                builder.ConfigureDefaults(options => options.Retry.Mode = RetryMode.Exponential);

                // Advanced configure global defaults
                builder.ConfigureDefaults((options, provider) =>  options.AddPolicy(provider.GetService<DependencyInjectionEnabledPolicy>(), HttpPipelinePosition.PerCall));

                // Register blob service client and initialize it using the Storage section of configuration
                builder.AddBlobServiceClient(Configuration.GetSection("Storage"))
                        .WithVersion(BlobClientOptions.ServiceVersion.V2019_02_02);
            });
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        #region Snippet:Inject
        public void Configure(IApplicationBuilder app, SecretClient secretClient, IAzureClientFactory<BlobServiceClient> blobClientFactory)
        #endregion
        {
            #region Snippet:ResolveNamed
            BlobServiceClient blobServiceClient = blobClientFactory.CreateClient("NamedBlobClient");
            #endregion

            app.Run(async context => {
                context.Response.ContentType = "text";

                await foreach (var response in blobServiceClient.GetBlobContainerClient("myblobcontainer").GetBlobsAsync())
                {
                    await context.Response.WriteAsync(response.Name + Environment.NewLine);
                }
            });
        }
    }
}
