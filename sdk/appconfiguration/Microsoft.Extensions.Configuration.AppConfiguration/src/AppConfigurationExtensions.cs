// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Data.AppConfiguration;
using Azure.Identity;
using Microsoft.Extensions.Configuration.AppConfiguration;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering <see cref="AppConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public static class AppConfigurationExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Azure App Configuration.
        /// The <see cref="ConfigurationClient"/> is created from the specified configuration section using
        /// <see cref="ConfigurationClientSettings"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="ConfigurationClientSettings"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAppConfigurations(
            this IConfigurationBuilder configurationBuilder,
            string sectionName)
        {
            return AddAppConfigurations(configurationBuilder, sectionName, null);
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Azure App Configuration.
        /// The <see cref="ConfigurationClient"/> is created from the specified configuration section using
        /// <see cref="ConfigurationClientSettings"/>. The <paramref name="configureSettings"/> callback can be used
        /// to modify the settings before the client is created.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="sectionName">The name of the configuration section that contains the <see cref="ConfigurationClientSettings"/>.</param>
        /// <param name="configureSettings">An optional callback to configure the <see cref="ConfigurationClientSettings"/> before the client is created.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddAppConfigurations(
            this IConfigurationBuilder configurationBuilder,
            string sectionName,
            Action<ConfigurationClientSettings> configureSettings)
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
            ConfigurationClientSettings settings = configuration.GetAzureClientSettings<ConfigurationClientSettings>(sectionName);
            configureSettings?.Invoke(settings);

            ConfigurationClient client = new ConfigurationClient(settings);
            configurationBuilder.Add(new AppConfigurationSource(client, new AppConfigurationOptions()));

            return configurationBuilder;
        }
    }
}
