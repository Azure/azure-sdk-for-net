// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.TextAnalytics;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="TextAnalyticsClient"/> client to clients builder.
    /// </summary>
    public static class TextAnalyticsClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="TextAnalyticsClient"/> instance with the provided <paramref name="endpoint"/>.
        /// </summary>
        public static IAzureClientBuilder<TextAnalyticsClient, TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<TextAnalyticsClient, TextAnalyticsClientOptions>((options, credential) => new TextAnalyticsClient(endpoint, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="TextAnalyticsClient"/> instance with the provided <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        public static IAzureClientBuilder<TextAnalyticsClient, TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextAnalyticsClient, TextAnalyticsClientOptions>(options => new TextAnalyticsClient(endpoint, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="TextAnalyticsClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<TextAnalyticsClient, TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TextAnalyticsClient, TextAnalyticsClientOptions>(configuration);
        }
    }
}
