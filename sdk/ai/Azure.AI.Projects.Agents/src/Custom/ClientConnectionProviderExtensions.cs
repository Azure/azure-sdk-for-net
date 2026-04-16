// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Agents;

public static partial class ClientConnectionProviderExtensions
{
    extension(ClientConnectionProvider connectionProvider)
    {
        public AgentAdministrationClient GetProjectAgentsClient(Uri endpoint=null, AgentAdministrationClientOptions options=null)
        {
            ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.AgentsPipelinePassthrough");
            ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
            options ??= new();
            // If the option without endpoint were provided, make sure, we still set it.
            endpoint ??= new(pipelineConnection.Locator);
            return new AgentAdministrationClient(smuggledPipeline, endpoint, options.Version);
        }
    }
}
