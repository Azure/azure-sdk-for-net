// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Identity;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.AIFoundry
{
    /// <summary>
    /// A CloudMachine feature that configures an AI Foundry project and optionally prepares resources for provisioning in the future.
    /// </summary>
    public class AIFoundryFeature : CloudMachineFeature
    {
        private readonly string _connectionString;

        // Group the IDs by ConnectionType for future expansions or custom logic.
        private static readonly string[] s_openAiIds = new[]
        {
            "Azure.AI.OpenAI.AzureOpenAIClient",
            "OpenAI.Chat.ChatClient",
            "OpenAI.Embeddings.EmbeddingClient"
        };

        private static readonly string[] s_inferenceIds = new[]
        {
            "Azure.AI.Inference.ChatCompletionsClient",
            "Azure.AI.Inference.EmbeddingsClient"
        };

        private static readonly string[] s_searchIds = new[]
        {
            "Azure.Search.Documents.SearchClient",
            "Azure.Search.Documents.Indexes.SearchIndexClient",
            "Azure.Search.Documents.Indexes.SearchIndexerClient"
        };

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
        /// Emit the Foundry connection(s) into the shared <see cref="ConnectionCollection"/>.
        /// </summary>
        /// <param name="connections">The global collection of <see cref="ClientConnection"/> objects for this CloudMachine. </param>
        /// <param name="cmId">The unique CloudMachine ID</param>
        protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
        {
            const string foundryId = "Azure.AI.Projects.AIProjectClient";
            connections.Add(new ClientConnection(foundryId, _connectionString));

            var foundryConnections = new AIFoundryConnections(_connectionString, new DefaultAzureCredential());
            foreach (var id in s_openAiIds)
            {
                connections.Add(foundryConnections.GetFoundryConnection(id));
            }

            foreach (var id in s_inferenceIds)
            {
                connections.Add(foundryConnections.GetFoundryConnection(id));
            }

            foreach (var id in s_searchIds)
            {
                connections.Add(foundryConnections.GetFoundryConnection(id));
            }
        }

        /// <summary>
        /// Emit any necessary resources for provisioning (currently no-op).
        /// </summary>
        /// <param name="cm">The CloudMachineInfrastructure context.</param>
        /// <returns>A placeholder or no-op resource, as provisioning is out-of-band for now.</returns>
        protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cm)
        {
            // In the future, generate real provisioning resources for Foundry
            return new NoOpResource();
        }
    }
}
