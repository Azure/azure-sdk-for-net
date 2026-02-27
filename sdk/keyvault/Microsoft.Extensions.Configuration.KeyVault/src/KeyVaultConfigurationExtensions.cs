// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration.KeyVault;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering <see cref="KeyVaultConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public static class KeyVaultConfigurationExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Azure Key Vault.
        /// The <see cref="SecretClient"/> is created from the specified configuration section using
        /// <see cref="SecretClientSettings"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="SecretClientSettings"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="SecretClientSettings"/>.</param>
        /// <param name="configureSettings">An optional callback to configure the <see cref="SecretClientSettings"/> before the client is created.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddKeyVaultSecrets(
            this IConfigurationBuilder configurationBuilder,
            string sectionName,
            Action<SecretClientSettings> configureSettings)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException(nameof(configurationBuilder));
            }
            if (string.IsNullOrEmpty(sectionName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(sectionName));
            }

            IConfiguration configuration = configurationBuilder.Build();
            SecretClientSettings settings = configuration.GetAzureClientSettings<SecretClientSettings>(sectionName);
            configureSettings?.Invoke(settings);

            SecretClient client = new SecretClient(settings);
            configurationBuilder.Add(new KeyVaultConfigurationSource(client, new KeyVaultConfigurationOptions()));

            return configurationBuilder;
        }
    }
}
