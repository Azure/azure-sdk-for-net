// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable AAIP001
#pragma warning disable SCME0001

namespace Azure.AI.Extensions.OpenAI;

public static partial class AzureAIExtensions
{
    extension(ResponseResult response)
    {
        /// <summary> Gets the agent associated with the response. </summary>
        public AgentReference Agent => response.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);

        /// <summary> Gets the conversation associated with the response. </summary>
        public string AgentConversationId => response.Patch.GetStringEx("$.conversation.id"u8);
    }

    extension(CreateResponseOptions options)
    {
        /// <summary> Gets or sets the agent associated with the response options. </summary>
        public AgentReference Agent
        {
            get => options.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
            set => options.Patch.SetOrClearEx("$.agent_reference"u8, "$.agent_reference"u8, value);
        }

        /// <summary> Gets or sets the conversation associated with the response options. </summary>
        public string AgentConversationId
        {
            get => options.Patch.GetStringEx("$.conversation.id"u8);
            set => options.Patch.SetOrClearEx("$.conversation.id"u8, "$.conversation"u8, value);
        }
    }

    /// <summary> Creates a response using a legacy conversation model. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ClientResult<ResponseResult> CreateResponse(this ResponsesClient responseClient, ProjectConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
        => CreateResponse(responseClient, ToNativeConversation(conversation), agentRef, cancellationToken);

    /// <summary> Creates a response using a legacy conversation model. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Task<ClientResult<ResponseResult>> CreateResponseAsync(this ResponsesClient responseClient, ProjectConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
        => CreateResponseAsync(responseClient, ToNativeConversation(conversation), agentRef, cancellationToken);

    private static ConversationResource ToNativeConversation(ProjectConversation conversation)
    {
        Argument.AssertNotNull(conversation, nameof(conversation));
        return ModelReaderWriter.Read<ConversationResource>(
            ModelReaderWriter.Write(conversation, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default),
            ModelReaderWriterOptions.Json, OpenAIContext.Default);
    }
}
