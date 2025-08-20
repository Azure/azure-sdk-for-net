// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Data.AppConfiguration;

//TODO: there is no way to only suppress a single member of a static class so we need to have everything custom here.
//The issue here is that the custom code made one of the constructors internal and we aren't catching ExistingType correctly for low level client
[assembly: CodeGenSuppressType("DataAppConfigurationClientBuilderExtensions")]

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="ConfigurationClient"/> client to clients builder.
    /// </summary>
    public static partial class ConfigurationClientBuilderExtensions
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

        /// <summary> Registers a <see cref="ConfigurationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<ConfigurationClient, ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ConfigurationClient, ConfigurationClientOptions>(configuration);
        }
    }
}
