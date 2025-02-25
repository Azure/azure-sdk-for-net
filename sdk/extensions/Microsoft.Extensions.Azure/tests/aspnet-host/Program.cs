// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

var app = builder.Build();
var secretClient = app.Services.GetRequiredService<SecretClient>();

app.MapGet("/keyvault", () => secretClient.VaultUri.AbsoluteUri);
app.Run();

// Make the implicit Program class public so test projects can access it.
public partial class Program { }
