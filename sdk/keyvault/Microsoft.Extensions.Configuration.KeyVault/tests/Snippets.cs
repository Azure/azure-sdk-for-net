// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Configuration.KeyVault.Tests
{
    public class Snippets
    {
        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Snippet code")]
        public void ConfigurationAddKeyVaultSecrets()
        {
            #region Snippet:ConfigurationAddKeyVaultSecrets
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Configuration.AddKeyVaultSecrets("KeyVault");
            builder.AddClient<MyClient, MyClientSettings>("MyClient");

            IHost host = builder.Build();
            MyClient client = host.Services.GetRequiredService<MyClient>();
            #endregion
        }
    }
}
