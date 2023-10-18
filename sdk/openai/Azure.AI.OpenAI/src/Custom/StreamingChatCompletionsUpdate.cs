// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class StreamingChatCompletionsUpdate
    {
        public string Id { get; }

        public DateTimeOffset Created { get; }

        public ChatRole? Role { get; }

        public string ContentUpdate { get; }

        public string FunctionName { get; }

        public string FunctionArgumentsUpdate { get; }

        public string AuthorName { get; }

        public CompletionsFinishReason? FinishReason { get; }

        public int? ChoiceIndex { get; }

        public AzureChatExtensionsMessageContext AzureExtensionsContext { get; }

        internal StreamingChatCompletionsUpdate(
            string id,
            DateTimeOffset created,
            int? choiceIndex = null,
            ChatRole? role = null,
            string authorName = null,
            string contentUpdate = null,
            CompletionsFinishReason? finishReason = null,
            string functionName = null,
            string functionArgumentsUpdate = null,
            AzureChatExtensionsMessageContext azureExtensionsContext = null)
        {
            Id = id;
            Created = created;
            ChoiceIndex = choiceIndex;
            Role = role;
            AuthorName = authorName;
            ContentUpdate = contentUpdate;
            FinishReason = finishReason;
            FunctionName = functionName;
            FunctionArgumentsUpdate = functionArgumentsUpdate;
            AzureExtensionsContext = azureExtensionsContext;
        }
    }
}
