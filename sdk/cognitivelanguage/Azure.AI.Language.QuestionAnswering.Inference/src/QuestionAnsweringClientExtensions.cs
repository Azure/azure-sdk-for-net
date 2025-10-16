// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to register the Question Answering inference client.
    /// </summary>
    public static partial class QuestionAnsweringClientExtensions
    {
        public static IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            Azure.AI.Language.QuestionAnswering.Inference.AILanguageQuestionAnsweringInferenceClientBuilderExtensions.AddQuestionAnsweringClient(builder, endpoint, credential);

        public static IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            Azure.AI.Language.QuestionAnswering.Inference.AILanguageQuestionAnsweringInferenceClientBuilderExtensions.AddQuestionAnsweringClient(builder, endpoint);

        public static IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            Azure.AI.Language.QuestionAnswering.Inference.AILanguageQuestionAnsweringInferenceClientBuilderExtensions.AddQuestionAnsweringClient(builder, configuration);
    }
}
