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
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME ?? "my-ai-search-connection-name";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = projectClient.Indexes.CreateOrUpdate(
                name: indexName,
                version: indexVersion,
                content: content
            );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            SearchIndex retrievedIndex = projectClient.Indexes.Get(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            foreach (SearchIndex version in projectClient.Indexes.GetVersions(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine($"Listing all Indices:");
            foreach (SearchIndex version in projectClient.Indexes.Get())
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
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME ?? "my-ai-search-connection-name";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = await projectClient.Indexes.CreateOrUpdateAsync(
                name: indexName,
                version: indexVersion,
                content: content
            );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            SearchIndex retrievedIndex = await projectClient.Indexes.GetAsync(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            await foreach (SearchIndex version in projectClient.Indexes.GetVersionsAsync(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine($"Listing all Indices:");
            await foreach (SearchIndex version in projectClient.Indexes.GetAsync())
            {
                Console.WriteLine(version);
            }

            Console.WriteLine("Delete the Index version created above:");
            await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion);
            #endregion
        }
    }
}
