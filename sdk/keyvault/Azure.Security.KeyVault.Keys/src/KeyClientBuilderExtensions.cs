// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to <see cref="KeyClient"/> or <see cref="CryptographyClient"/> to clients builder.
    /// </summary>
    public static class KeyClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        /// <typeparam name="TBuilder">The type of builder to extend.</typeparam>
        /// <param name="builder">The builder to extend.</param>
        /// <param name="vaultUri">The URI to an Azure Key Vault, for example: https://my-vault.vault.azure.net</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<KeyClient, KeyClientOptions> AddKeyClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<KeyClient, KeyClientOptions>((options, cred) => new KeyClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="KeyClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        /// <typeparam name="TBuilder">The type of builder to extend.</typeparam>
        /// <typeparam name="TConfiguration">The type of configuration to use for the client builder.</typeparam>
        /// <param name="builder">The builder to extend.</param>
        /// <param name="configuration">The configuration to use for the client builder.</param>
        /// <returns>An Azure client builder.</returns>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<KeyClient, KeyClientOptions> AddKeyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<KeyClient, KeyClientOptions>(configuration);
        }

        /// <summary>
        /// Registers a <see cref="CryptographyClient "/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        /// <typeparam name="TBuilder">The type of builder to extend.</typeparam>
        /// <param name="builder">The builder to extend.</param>
        /// <param name="vaultUri">The URI to a specific key in an Azure Key Vault, for example: https://my-vault.vault.azure.net/keys/my-key</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<CryptographyClient, CryptographyClientOptions> AddCryptographyClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<CryptographyClient, CryptographyClientOptions>((options, cred) => new CryptographyClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="CryptographyClient "/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        /// <typeparam name="TBuilder">The type of builder to extend.</typeparam>
        /// <typeparam name="TConfiguration">The type of configuration to use for the client builder.</typeparam>
        /// <param name="builder">The builder to extend.</param>
        /// <param name="configuration">The configuration to use for the client builder.</param>
        /// <returns>An Azure client builder.</returns>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<CryptographyClient, CryptographyClientOptions> AddCryptographyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CryptographyClient, CryptographyClientOptions>(configuration);
        }
    }
}
