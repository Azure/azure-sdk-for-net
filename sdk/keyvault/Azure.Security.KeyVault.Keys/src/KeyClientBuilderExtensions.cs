// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Microsoft.Extensions.Azure
#pragma warning restore AZC0001
{
    /// <summary>
    /// Extension methods to <see cref="KeyClient"/> or <see cref="CryptographyClient"/> to clients builder.
    /// </summary>
    public static class KeyClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        public static IAzureClientBuilder<KeyClient, KeyClientOptions> AddKeyClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<KeyClient, KeyClientOptions>((options, cred) => new KeyClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<KeyClient, KeyClientOptions> AddKeyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<KeyClient, KeyClientOptions>(configuration);
        }

        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        public static IAzureClientBuilder<CryptographyClient, CryptographyClientOptions> AddCryptographyClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<CryptographyClient, CryptographyClientOptions>((options, cred) => new CryptographyClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<CryptographyClient, CryptographyClientOptions> AddCryptographyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CryptographyClient, CryptographyClientOptions>(configuration);
        }
    }
}
