// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Data.AppConfiguration;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="ConfigurationClient"/> client to clients builder.
    /// </summary>
    public static class ConfigurationClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="ConfigurationClient"/> instance with the provided <paramref name="connectionString"/>.
        /// </summary>
        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ConfigurationClient, ConfigurationClientOptions>(options => new ConfigurationClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="ConfigurationClient"/> instance with the provided <paramref name="configurationUri"/>.
        /// </summary>
        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, Uri configurationUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ConfigurationClient, ConfigurationClientOptions>((options, cred) => new ConfigurationClient(configurationUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="ConfigurationClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ConfigurationClient, ConfigurationClientOptions>(configuration);
        }
    }
}
