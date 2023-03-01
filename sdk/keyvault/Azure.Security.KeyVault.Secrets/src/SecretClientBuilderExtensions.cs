// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Security.KeyVault.Secrets;

[assembly: CodeGenSuppressType("SecretClientBuilderExtensions")]

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="SecretClient"/> to clients builder.
    /// </summary>
    public static class SecretClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="SecretClient"/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        public static IAzureClientBuilder<SecretClient, SecretClientOptions> AddSecretClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<SecretClient, SecretClientOptions>((options, cred) => new SecretClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="SecretClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<SecretClient, SecretClientOptions> AddSecretClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<SecretClient, SecretClientOptions>(configuration);
        }
    }
}
