// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Azure.Samples;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region Snippet:ConfigureServices
// Registering policy to use in ConfigureDefaults later
builder.Services.AddSingleton<DependencyInjectionEnabledPolicy>();

builder.Services.AddAzureClients(azureBuilder => {
    // Register blob service client and initialize it using the KeyVault section of configuration
    azureBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"))
        // Set the name for this client registration
        .WithName("NamedBlobClient")
        // Set the credential for this client registration
        .WithCredential(new ClientSecretCredential("<tenant_id>", "<client_id>", "<client_secret>"))
        // Configure the client options
        .ConfigureOptions(options => options.Retry.MaxRetries = 10);

    // Adds a secret client using the provided endpoint and default credential set later
    azureBuilder.AddSecretClient(new Uri("http://my.keyvault.com"));

    // Configures environment credential to be used by default for all clients that require TokenCredential
    // and doesn't override it on per registration level
    azureBuilder.UseCredential(new EnvironmentCredential());

    // This would use configuration for auth and client settings
    azureBuilder.ConfigureDefaults(builder.Configuration.GetSection("Default"));

    // Configure global retry mode
    azureBuilder.ConfigureDefaults(options => options.Retry.Mode = RetryMode.Exponential);

    // Advanced configure global defaults
    azureBuilder.ConfigureDefaults((options, provider) => options.AddPolicy(provider.GetService<DependencyInjectionEnabledPolicy>(), HttpPipelinePosition.PerCall));

    // Register blob service client and initialize it using the Storage section of configuration
    azureBuilder.AddBlobServiceClient(builder.Configuration.GetSection("Storage"))
            .WithVersion(BlobClientOptions.ServiceVersion.V2019_02_02);
});
#endregion

var app = builder.Build();

#region Snippet:Inject
var secretClient = app.Services.GetRequiredService<SecretClient>();
var blobClientFactory = app.Services.GetRequiredService<IAzureClientFactory<BlobServiceClient>>();
#endregion

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

app.Run();