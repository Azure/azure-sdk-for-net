// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Diagnostics;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Indexes : SamplesBase<AIProjectsTestEnvironment>
    {
        private AIProjectClient CreateDebugClient(string endpoint)
        {
            var options = new AIProjectClientOptions();

            // Add custom pipeline policy for debugging
            options.AddPolicy(new DebugPipelinePolicy(), PipelinePosition.PerCall);

            return new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential(), options);
        }

        // Custom pipeline policy for debugging System.ClientModel requests
        private class DebugPipelinePolicy : PipelinePolicy
        {
            public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                Console.WriteLine($"Request: {message.Request.Method} {message.Request.Uri}");

                ProcessNext(message, pipeline, index);

                Console.WriteLine($"Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");
            }

            public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                Console.WriteLine($"Async Request: {message.Request.Method} {message.Request.Uri}");

                var result = ProcessNextAsync(message, pipeline, index);

                Console.WriteLine($"Async Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");
                return result;
            }
        }

        [Test]
        [SyncOnly]
        public void IndexesExample()
        {
            #region Snippet:AI_Projects_IndexesExampleSync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var indexName = Environment.GetEnvironmentVariable("INDEX_NAME") ?? "my-index";
            var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION") ?? "1.0";
            var aiSearchConnectionName = Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME") ?? "my-ai-search-connection-name";
            var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME") ?? "my-ai-search-index-name";

            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME ?? "my-ai-search-connection-name";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";

            AIProjectClient projectClient = CreateDebugClient(endpoint);
#endif

            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = (SearchIndex)projectClient.Indexes.CreateOrUpdate(
                name: indexName,
                version: indexVersion,
                content: content
            );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            SearchIndex retrievedIndex = projectClient.Indexes.GetIndex(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            foreach (SearchIndex version in projectClient.Indexes.GetIndexVersions(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine($"Listing all Indices:");
            foreach (SearchIndex version in projectClient.Indexes.GetIndexes())
            {
                Console.WriteLine(version);
            }

            Console.WriteLine("Delete the Index version created above:");
            projectClient.Indexes.Delete(name: indexName, version: indexVersion);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task IndexesExampleAsync()
        {
            #region Snippet:AI_Projects_IndexesExampleAsync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var indexName = Environment.GetEnvironmentVariable("INDEX_NAME") ?? "my-index";
            var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION") ?? "1.0";
            var aiSearchConnectionName = Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME") ?? "my-ai-search-connection-name";
            var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME") ?? "my-ai-search-index-name";

            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME ?? "my-ai-search-connection-name";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";

            AIProjectClient projectClient = CreateDebugClient(endpoint);
#endif

            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = (SearchIndex)await projectClient.Indexes.CreateOrUpdateAsync(
                name: indexName,
                version: indexVersion,
                content: content
            );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            SearchIndex retrievedIndex = await projectClient.Indexes.GetIndexAsync(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            await foreach (SearchIndex version in projectClient.Indexes.GetIndexVersionsAsync(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine($"Listing all Indices:");
            await foreach (SearchIndex version in projectClient.Indexes.GetIndexesAsync())
            {
                Console.WriteLine(version);
            }

            Console.WriteLine("Delete the Index version created above:");
            await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion);
            #endregion
        }
    }
}
