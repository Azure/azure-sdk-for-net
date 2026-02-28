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
        public AgentsClient GetProjectOpenAIClient(ClientPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.DirectPipelinePassthrough");
            if (pipelineConnection.CredentialKind == CredentialKind.None)
            {
                ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
                endpoint ??= new(pipelineConnection.Locator);
                return new AgentsClient(smuggledPipeline, endpoint, apiVersion);
            }
            return null;
        }
    }
}
