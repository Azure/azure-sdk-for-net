// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;

namespace Azure.ApplicationModel.Configuration
{
    public static class ConfigurationClientBuilderExtensions
    {
        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddAppConfiguration<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder: IAzureClientsBuilder
        {
            return builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(options => new ConfigurationClient(connectionString, options));
        }

        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddAppConfiguration<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClient<ConfigurationClient, ConfigurationClientOptions>(configuration);
        }
    }
}
