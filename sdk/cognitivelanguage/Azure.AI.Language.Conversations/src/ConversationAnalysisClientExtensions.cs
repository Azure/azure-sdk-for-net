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
        [Obsolete]
        public static IAzureClientBuilder<ConversationAuthoringClient, ConversationsClientOptions> AddConversationAuthoringClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        public static IAzureClientBuilder<ConversationAuthoringClient, ConversationsClientOptions> AddConversationAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            throw new NotSupportedException();
        }
    }
}
