// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.AI.Projects.OpenAI;
using OpenAI;

namespace Azure.AI.Agents;

public static partial class ClientConnectionProviderExtensions
{
    public static ProjectOpenAIClient GetProjectOpenAIClient(this ClientConnectionProvider connectionProvider, OpenAIClientOptions options)
    {
        ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.DirectPipelinePassthrough");
        if (pipelineConnection.CredentialKind == CredentialKind.None)
        {
            ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
            return new ProjectOpenAIClient(smuggledPipeline, options);
        }
        return null;
    }

    public static AgentClient GetAgentClient(this ClientConnectionProvider clientConnectionProvider, AgentClientOptions agentClientOptions = default)
    {
        ClientConnection chatConnection = clientConnectionProvider.GetConnection("OpenAI.Chat.ChatClient");
        Uri endpoint = new(chatConnection.Locator);
        AuthenticationTokenProvider tokenProvider = chatConnection.Credential as AuthenticationTokenProvider;
        return new AgentClient(endpoint, tokenProvider, agentClientOptions);
    }
}
