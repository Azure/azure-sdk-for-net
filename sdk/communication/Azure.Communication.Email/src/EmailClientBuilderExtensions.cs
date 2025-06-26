// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Communication.Email;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="EmailClient"/> client to clients builder.
    /// </summary>
    public static class EmailClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="EmailClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<EmailClient, EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EmailClient, EmailClientOptions>(options => new EmailClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="EmailClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="azureKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<EmailClient, EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, Uri serviceUri, AzureKeyCredential azureKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EmailClient, EmailClientOptions>(options => new EmailClient(serviceUri, azureKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="EmailClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<EmailClient, EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EmailClient, EmailClientOptions>((options, cred) => new EmailClient(serviceUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="EmailClient"/> instance with the provided <paramref name="configuration"/>
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<EmailClient, EmailClientOptions> AddEmailClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EmailClient, EmailClientOptions>(configuration);
        }
    }
}
