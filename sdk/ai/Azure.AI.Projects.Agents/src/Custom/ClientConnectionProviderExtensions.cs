// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Agents;

public static partial class ClientConnectionProviderExtensions
{
    extension(ClientConnectionProvider connectionProvider)
    {
        public AgentsClient GetProjectAgentsClient(AgentsClientOptions options=null)
        {
            ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.AgentsPipelinePassthrough");
            ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
            options ??= new()
            {
                Endpoint = new Uri(pipelineConnection.Locator),
            };
            // If the option without endpoint were provided, make sure, we still set it.
            options.Endpoint ??= new(pipelineConnection.Locator);
            return new AgentsClient(smuggledPipeline, options.Endpoint, options.ApiVersion);
        }
    }
}
