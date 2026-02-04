// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Identity;
using Azure.Projects.Core;
using Azure.Provisioning.AIFoundry;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.AIFoundry
{
    /// <summary>
    /// A feature that configures an AI Foundry project and optionally prepares resources for provisioning in the future.
    /// </summary>
    public class AIProjectFeature : AzureProjectFeature
    {
        private Uri _endpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="AIProjectFeature"/> class.
        /// </summary>
        /// <param name="endpoint">
        /// The Foundry endpoint URI for the AI Project.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="endpoint"/> is null.
        /// </exception>
        public AIProjectFeature(Uri endpoint) : this()
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            _endpoint = endpoint;
        }

        /// <summary>
        /// Creates a new feature for provisioning.
        /// </summary>
        public AIProjectFeature()
        {
        }

        /// <summary>
        /// Returns the connection string for the AI Project endpoint.
        /// </summary>
        public List<ClientConnection> Connections { get; set; } = new List<ClientConnection>();

        private  void EmitConnections(ICollection<ClientConnection> connections, string cmId)
        {
            if (_endpoint != null)
            {
                var foundryConnections = new AIFoundryConnections(_endpoint, new DefaultAzureCredential());

                // Add OpenAI connections
                connections.Add(foundryConnections.GetConnection("Azure.AI.OpenAI.AzureOpenAIClient"));
                connections.Add(foundryConnections.GetConnection("OpenAI.Chat.ChatClient"));
                connections.Add(foundryConnections.GetConnection("OpenAI.Embeddings.EmbeddingClient"));

                // Add Inference connections
                connections.Add(foundryConnections.GetConnection("Azure.AI.Inference.ChatCompletionsClient"));
                connections.Add(foundryConnections.GetConnection("Azure.AI.Inference.EmbeddingsClient"));

                // Add Search connections
                connections.Add(foundryConnections.GetConnection("Azure.Search.Documents.SearchClient"));
                connections.Add(foundryConnections.GetConnection("Azure.Search.Documents.Indexes.SearchIndexClient"));
                connections.Add(foundryConnections.GetConnection("Azure.Search.Documents.Indexes.SearchIndexerClient"));
            }
        }

        /// <summary>
        /// Emit any necessary resources for provisioning (currently no-op).
        /// </summary>
        /// <param name="infrastructure">The ProjectInfrastructure context.</param>
        protected override void EmitConstructs(ProjectInfrastructure infrastructure)
        {
            var cmId = infrastructure.ProjectId;
            AIFoundryHubCdk hub = new($"ai_hub", $"{cmId}_hub");
            AIFoundryProjectCdk project = new($"ai_project", $"{cmId}_project", hub);

            infrastructure.AddConstruct(Id + "_hub", hub);
            infrastructure.AddConstruct(Id + "_project", project);

            EmitConnections(Connections, cmId);
            for (int i = 0; i < Connections.Count; i++)
            {
                ClientConnection connection = Connections[i];
                AIFoundryConnectionCdk connectionCdk = new($"{cmId}connection{i}", connection.Id, connection.Locator, project);
                infrastructure.AddConstruct(Id + "_connection" + i, connectionCdk);
            }

            if (_endpoint != null)
            {
                EmitConnection(infrastructure, "Azure.AI.Projects.AIProjectClient", _endpoint.AbsoluteUri);
            }
        }
    }
}
