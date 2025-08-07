// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering <see cref="AzureKeyVaultConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class AzureKeyVaultConfigurationExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="vaultUri">The Azure Key Vault uri.</param>
        /// <param name="credential">The credential to use for authentication.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAzureKeyVault(
            this IConfigurationBuilder configurationBuilder,
            Uri vaultUri,
            TokenCredential credential)
        {
            return AddAzureKeyVault(configurationBuilder, vaultUri, credential, KeyVaultSecretManager.Instance);
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="vaultUri">Azure Key Vault uri.</param>
        /// <param name="credential">The credential to use for authentication.</param>
        /// <param name="manager">The <see cref="KeyVaultSecretManager"/> instance used to control secret loading.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAzureKeyVault(
            this IConfigurationBuilder configurationBuilder,
            Uri vaultUri,
            TokenCredential credential,
            KeyVaultSecretManager manager)
        {
            return AddAzureKeyVault(configurationBuilder, new SecretClient(vaultUri, credential), new AzureKeyVaultConfigurationOptions
            {
                Manager = manager
            });
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="manager">The <see cref="KeyVaultSecretManager"/> instance used to control secret loading.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAzureKeyVault(
            this IConfigurationBuilder configurationBuilder,
            SecretClient client,
            KeyVaultSecretManager manager)
        {
            return AddAzureKeyVault(configurationBuilder, client, new AzureKeyVaultConfigurationOptions()
            {
                Manager = manager
            });
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="vaultUri">Azure Key Vault uri.</param>
        /// <param name="credential">The credential to use for authentication.</param>
        /// <param name="options">The <see cref="AzureKeyVaultConfigurationOptions"/> to use.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAzureKeyVault(
            this IConfigurationBuilder configurationBuilder,
            Uri vaultUri,
            TokenCredential credential,
            AzureKeyVaultConfigurationOptions options)
        {
            return configurationBuilder.AddAzureKeyVault(new SecretClient(vaultUri, credential), options);
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="AzureKeyVaultConfigurationOptions"/> to use.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAzureKeyVault(
            this IConfigurationBuilder configurationBuilder,
            SecretClient client,
            AzureKeyVaultConfigurationOptions options)
        {
            Argument.AssertNotNull(configurationBuilder, nameof(configurationBuilder));
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(options.Manager, $"{nameof(options)}.{nameof(options.Manager)}");

            configurationBuilder.Add(new AzureKeyVaultConfigurationSource(client, options));

            return configurationBuilder;
        }
    }
}
