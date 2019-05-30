// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ApplicationModel.Configuration
{
    public static class AppConfigurationAzureClientBuilderExtensions
    {
        public static TBuilder AddAppConfiguration<TBuilder>(this TBuilder builder,
            string name,
            string connectionString,
            Action<ConfigurationClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilder
        {
            builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(name, options => new ConfigurationClient(connectionString, options));
            builder.ConfigureClientOptions<ConfigurationClientOptions>(name, configureOptions);
            return builder;
        }

        public static TBuilder AddAppConfiguration<TBuilder, TConfiguration>(this TBuilder builder, string name, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(name,
                options => CreateClientFromConfiguration(builder.AsDictionary(configuration), options));
            builder.ConfigureClientOptions<ConfigurationClientOptions>(name, options => builder.Bind(configuration, options));
            return builder;
        }

        private static ConfigurationClient CreateClientFromConfiguration(
            IReadOnlyDictionary<string, string> configuration,
            ConfigurationClientOptions options)
        {
            // TODO: Extract a helper type

            if (configuration["connectionString"] is string connectionString)
            {
                return new ConfigurationClient(connectionString, options);
            }

            throw new InvalidOperationException("Unable to resolve connection options from configuration. Supported combinations are: connectionString");
        }
    }
}
