// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.Agents;

public static partial class ClientConnectionProviderExtensions
{
    private static AgentsClient s_cachedAgentsClient = null;

    extension(ClientConnectionProvider target)
    {
        public AgentsClient GetAgentsClient(AgentsClientOptions options = default)
        {
            ClientConnection chatConnection = target.GetConnection("OpenAI.Chat.ChatClient");
            Uri endpoint = new(chatConnection.Locator);
            AuthenticationTokenProvider tokenProvider = chatConnection.Credential as AuthenticationTokenProvider;
            return new AgentsClient(endpoint, tokenProvider, options);
        }
        public AgentsClient Agents => s_cachedAgentsClient ??= GetAgentsClient(target, options: null);
    }
}
