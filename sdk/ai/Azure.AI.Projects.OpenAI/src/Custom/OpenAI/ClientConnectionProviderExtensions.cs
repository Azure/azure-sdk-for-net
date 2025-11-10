// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI;

namespace Azure.AI.Projects.OpenAI;

public static partial class ClientConnectionProviderExtensions
{
    extension(ClientConnectionProvider connectionProvider)
    {
        public ProjectOpenAIClient GetProjectOpenAIClient(ProjectOpenAIClientOptions options = null)
        {
            ClientConnection pipelineConnection = connectionProvider.GetConnection("Internal.DirectPipelinePassthrough");
            if (pipelineConnection.CredentialKind == CredentialKind.None)
            {
                ClientPipeline smuggledPipeline = pipelineConnection.Credential as ClientPipeline;
                options ??= new()
                {
                    Endpoint = new Uri(pipelineConnection.Locator),
                };
                return new ProjectOpenAIClient(smuggledPipeline, options);
            }
            return null;
        }
    }
}
