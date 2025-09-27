// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Agents.Persistent;
using Azure.Core.TestFramework;
using NUnit.Framework;
using ToolResources = Azure.AI.Agents.Persistent.ToolResources;

namespace Azure.AI.Projects.Tests
{
    public class Sample_AzureAISearchToolUsingConnections : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ConnectionsExample()
        {
            #region Snippet:AI_Projects_AzureAISearchInitializeProjectClient
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
            var indexName = Environment.GetEnvironmentVariable("INDEX_NAME");
            var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION");
            var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";
#endif

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            #region Snippet:AI_Projects_AzureAISearchIndexCreation
            AIProjectConnection aiSearchConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureAISearch);

            Console.WriteLine("Create a local AzureAISearchIndex with configurable data, referencing an existing AI Search resource");
            AzureAISearchIndex searchIndex = new AzureAISearchIndex(aiSearchConnection.Name, aiSearchIndexName)
            {
                Description = "Sample Index for testing"
            };

            Console.WriteLine($"Create the Project Index named `{indexName}` using the previously created local object");
            searchIndex = (AzureAISearchIndex)projectClient.Indexes.CreateOrUpdate(
                name: indexName,
                version: indexVersion,
                index: searchIndex
            );
            #endregion

            #region Snippet:AI_Projects_AzureAISearchToolUsingConnections
            var agentsClient = projectClient.GetPersistentAgentsClient();

            Console.WriteLine("Initialize agent AI search tool using the default connection and created index");
            var aiSearchToolResource = new AzureAISearchToolResource(
                indexConnectionId: aiSearchConnection.Id,
                indexName: indexName,
                queryType: AzureAISearchQueryType.Simple,
                topK: 3,
                filter: ""
            );
            ToolResources toolResource = new()
            {
                AzureAISearch = aiSearchToolResource
            };

            Console.WriteLine("Create agent with AI search tool");
            var agent = agentsClient.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "my-agent",
                instructions: "You are a helpful agent",
                tools: [new AzureAISearchToolDefinition()],
                toolResources: toolResource
            );
            #endregion
        }
    }
}
