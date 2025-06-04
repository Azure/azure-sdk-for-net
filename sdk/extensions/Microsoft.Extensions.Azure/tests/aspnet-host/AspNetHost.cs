// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER

using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core.Extensions.Tests;

public class AspNetHost
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Environment.ContentRootPath = "aspnet-host";

        builder.Services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
        });

        var app = builder.Build();
        var secretClient = app.Services.GetRequiredService<SecretClient>();

        app.MapGet("/keyvault", () => secretClient.VaultUri.AbsoluteUri);
        app.Run();
    }
}
#endif