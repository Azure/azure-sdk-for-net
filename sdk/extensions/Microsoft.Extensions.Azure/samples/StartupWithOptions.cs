// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure.Samples
{
    public class StartupWithOptions
    {
        #region Snippet:UsingOptionsForClientConstruction

        public class MyApplicationOptions
        {
            public Uri KeyVaultEndpoint { get; set; }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure a custom options instance
            services.Configure<MyApplicationOptions>(options => options.KeyVaultEndpoint = new Uri("http://localhost/"));

            services.AddAzureClients(builder =>
            {
                // Register a client using MyApplicationOptions to get constructor parameters
                builder.AddClient<SecretClient, SecretClientOptions>((provider, credential, options) =>
                {
                    var appOptions = provider.GetService<IOptions<MyApplicationOptions>>();
                    return new SecretClient(appOptions.Value.KeyVaultEndpoint, credential, options);
                });
            });
        }

        #endregion
    }
}