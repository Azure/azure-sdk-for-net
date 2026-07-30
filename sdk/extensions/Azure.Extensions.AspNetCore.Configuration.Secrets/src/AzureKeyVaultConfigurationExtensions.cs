// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
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

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Azure Key Vault.
        /// The <see cref="SecretClient"/> is created from the specified configuration section using
        /// <see cref="SecretClientSettings"/>.
        /// </summary>
        /// <remarks>
        /// This method uses the <c>Azure.Core</c> configuration extensions (built on <c>System.ClientModel</c>) to create a
        /// <see cref="SecretClient"/> from the specified configuration section. The section should contain the <c>VaultUri</c>
        /// and <c>Credential</c> properties. For more information, see
        /// <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md">Configuration and Dependency Injection for Azure SDK Clients</see>.
        /// </remarks>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="SecretClientSettings"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        [Experimental("SCME0002")]
        public static IConfigurationBuilder AddKeyVaultSecrets(
            this IConfigurationBuilder configurationBuilder,
            string sectionName)
        {
            return AddKeyVaultSecrets(configurationBuilder, sectionName, null);
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Azure Key Vault.
        /// The <see cref="SecretClient"/> is created from the specified configuration section using
        /// <see cref="SecretClientSettings"/>. The <paramref name="configureSettings"/> callback can be used
        /// to modify the settings before the client is created.
        /// </summary>
        /// <remarks>
        /// This method uses the <c>Azure.Core</c> configuration extensions (built on <c>System.ClientModel</c>) to create a
        /// <see cref="SecretClient"/> from the specified configuration section. The section should contain the <c>VaultUri</c>
        /// and <c>Credential</c> properties. For more information, see
        /// <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md">Configuration and Dependency Injection for Azure SDK Clients</see>.
        /// </remarks>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="SecretClientSettings"/>.</param>
        /// <param name="configureSettings">An optional callback to configure the <see cref="SecretClientSettings"/> before the client is created.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        [Experimental("SCME0002")]
        public static IConfigurationBuilder AddKeyVaultSecrets(
            this IConfigurationBuilder configurationBuilder,
            string sectionName,
            Action<SecretClientSettings> configureSettings)
        {
            Argument.AssertNotNull(configurationBuilder, nameof(configurationBuilder));
            Argument.AssertNotNullOrEmpty(sectionName, nameof(sectionName));

            IConfiguration configuration = configurationBuilder.Build();
            SecretClientSettings settings = configuration.GetAzureClientSettings<SecretClientSettings>(sectionName);
            configureSettings?.Invoke(settings);

            SecretClient client = new SecretClient(settings);
            configurationBuilder.Add(new AzureKeyVaultConfigurationSource(client, new AzureKeyVaultConfigurationOptions()));

            return configurationBuilder;
        }
    }
}
