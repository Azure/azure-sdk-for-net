// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.Agents;

public static partial class ClientConnectionProviderExtensions
{
    public static AgentsClient GetAgentsClient(this ClientConnectionProvider clientConnectionProvider, AgentsClientOptions agentsClientOptions = default)
    {
        ClientConnection chatConnection = clientConnectionProvider.GetConnection("OpenAI.Chat.ChatClient");
        Uri endpoint = new(chatConnection.Locator);
        AuthenticationTokenProvider tokenProvider = chatConnection.Credential as AuthenticationTokenProvider;
        return new AgentsClient(endpoint, tokenProvider, agentsClientOptions);
    }
}
