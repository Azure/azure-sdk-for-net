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
        public void ConfigureServices(IServiceCollection services)
        {
            // Registering policy to use in ConfigureDefaults later
            services.AddSingleton<DependencyInjectionEnabledPolicy>();

            services.AddAzureClients(builder => {

                builder.AddSecretClient(Configuration.GetSection("KeyVault"))
                    .WithName("Default")
                    .WithCredential(new DefaultAzureCredential())
                    .ConfigureOptions(options => options.Retry.MaxRetries = 10);

                builder.AddSecretClient(new Uri("http://my.keyvault.com"));

                builder.UseCredential(new DefaultAzureCredential());

                // This would use configuration for auth and client settings
                builder.ConfigureDefaults(Configuration.GetSection("Default"));

                // Configure global defaults
                builder.ConfigureDefaults(options => options.Retry.Mode = RetryMode.Exponential);

                // Advanced configure global defaults
                builder.ConfigureDefaults((options, provider) =>  options.AddPolicy(provider.GetService<DependencyInjectionEnabledPolicy>(), HttpPipelinePosition.PerCall));

                builder.AddBlobServiceClient(Configuration.GetSection("Storage"))
                        .WithVersion(BlobClientOptions.ServiceVersion.V2019_02_02);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SecretClient secretClient, BlobServiceClient blobServiceClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
