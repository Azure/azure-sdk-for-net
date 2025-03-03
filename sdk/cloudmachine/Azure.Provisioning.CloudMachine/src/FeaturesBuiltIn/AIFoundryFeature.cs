﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Identity;
using Azure.Provisioning.AIFoundry;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.AIFoundry
{
    /// <summary>
    /// A feature that configures an AI Foundry project and optionally prepares resources for provisioning in the future.
    /// </summary>
    public class AIFoundryFeature : AzureProjectFeature
    {
        private string? _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AIFoundryFeature"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The Foundry connection string for the AI Project endpoint.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="connectionString"/> is null or empty.
        /// </exception>
        public AIFoundryFeature(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates a new feature for provisioning.
        /// </summary>
        public AIFoundryFeature()
        {
        }

        public List<ClientConnection> Connections { get; set; } = new List<ClientConnection>();

        /// <summary>
        /// Emit the Foundry connection(s) into the shared <see cref="ConnectionCollection"/>.
        /// </summary>
        /// <param name="connections">The global collection of <see cref="ClientConnection"/> objects for this project. </param>
        /// <param name="cmId">The unique AzureProject ID</param>
        protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
        {
            if (_connectionString != null)
            {
                const string foundryId = "Azure.AI.Projects.AIProjectClient";
                connections.Add(new ClientConnection(foundryId, _connectionString));

                var foundryConnections = new AIFoundryConnections(_connectionString, new DefaultAzureCredential());

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
        /// <param name="cm">The ProjectInfrastructure context.</param>
        /// <returns>A placeholder or no-op resource, as provisioning is out-of-band for now.</returns>
        protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
        {
            var cmId = cm.Id;
            AIFoundryHubCdk hub = new($"{cmId}_hub", $"{cmId}_hub");
            AIFoundryProjectCdk project = new($"{cmId}_project", $"{cmId}_project", hub);

            cm.AddResource(hub);
            cm.AddResource(project);

            for (int i = 0; i < Connections.Count; i++)
            {
                ClientConnection connection = Connections[i];
                AIFoundryConnectionCdk connectionCdk = new($"{cmId}connection{i}", connection.Id, connection.Locator, project);
                cm.AddResource(connectionCdk);
            }

            return project;
        }
    }
}
