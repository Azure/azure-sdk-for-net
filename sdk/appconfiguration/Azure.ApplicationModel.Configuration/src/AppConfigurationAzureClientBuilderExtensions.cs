// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// App Configuration client builder
    /// </summary>
    public static class AppConfigurationAzureClientBuilderExtensions
    {
        public static TBuilder AddAppConfiguration<TBuilder>(this TBuilder builder,
            string name,
            string connectionString,
            Action<ConfigurationClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilder
        {
            builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(name, options => new ConfigurationClient(connectionString, options), configureOptions);
            return builder;
        }

        public static TBuilder AddAppConfiguration<TBuilder, TConfiguration>(this TBuilder builder, string name, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(name, configuration);
            return builder;
        }
    }
}
