// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

using Azure.AI.Extensions.OpenAI;

namespace Azure.AI.Projects;

/// <summary> Provides OpenAI client extensions for project client connections. </summary>
public static partial class ClientConnectionProviderExtensions
{
    extension(ClientConnectionProvider connectionProvider)
    {
        /// <summary> Gets a project OpenAI client from the client connection provider. </summary>
        /// <param name="options"> The options used to configure the project OpenAI client. </param>
        /// <returns> The project OpenAI client, or null when the provider does not contain a compatible connection. </returns>
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
                // If the option without endpoint were provided, make sure, we still set it.
                options.Endpoint = new Uri(pipelineConnection.Locator);
                // Also set the credential so that we can use it for hosted agents.
                pipelineConnection = connectionProvider.GetConnection(connectionId: "Internal.EndpointPipelineData");
                AuthenticationTokenProvider provider = pipelineConnection.Credential as AuthenticationTokenProvider;
                options.TokenProvider = provider;
                return new ProjectOpenAIClient(smuggledPipeline, options);
            }
            return null;
        }
    }
}
