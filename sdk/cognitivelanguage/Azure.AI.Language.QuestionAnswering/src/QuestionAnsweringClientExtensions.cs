// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;
using Azure.AI.Language.QuestionAnswering;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add Question Answering clients to the Azure client builder.
    /// </summary>
    [CodeGenType("AILanguageQuestionAnsweringClientBuilderExtensions")]
    public static partial class QuestionAnsweringClientExtensions
    {
        /// <summary>
        /// Registers a <see cref="QuestionAnsweringClient"/> instance with the provider <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<QuestionAnsweringClient, QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureKeyCredential credential) where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<QuestionAnsweringClient, QuestionAnsweringClientOptions>(options => new QuestionAnsweringClient(endpoint, credential, options));

        /// <summary>
        /// Registers a <see cref="QuestionAnsweringClient"/> instance with configuration loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <typeparam name="TConfiguration">Type of the client configuration.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<QuestionAnsweringClient, QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder, TConfiguration>(
            this TBuilder builder,
            TConfiguration configuration) where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<QuestionAnsweringClient, QuestionAnsweringClientOptions>(configuration);
    }
}
