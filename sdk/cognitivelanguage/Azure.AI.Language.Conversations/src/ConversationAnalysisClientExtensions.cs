// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    [CodeGenModel("AILanguageConversationsClientBuilderExtensions")]
    public static partial class ConversationAnalysisClientExtensions
    {
        /// <summary> Registers a <see cref="ConversationAuthoringClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>

        /// <returns>An Azure client builder for Conversation Authoring Client.</returns>
        [Obsolete("This method is obsolete and will be removed in a future release.", true)]
        public static IAzureClientBuilder<ConversationAuthoringClient, ConversationsClientOptions> AddConversationAuthoringClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            throw new NotSupportedException();
        }

        /// <summary> Registers a <see cref="ConversationAuthoringClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [Obsolete("This method is obsolete and will be removed in a future release.", true)]
        public static IAzureClientBuilder<ConversationAuthoringClient, ConversationsClientOptions> AddConversationAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            throw new NotSupportedException();
        }
    }
}
