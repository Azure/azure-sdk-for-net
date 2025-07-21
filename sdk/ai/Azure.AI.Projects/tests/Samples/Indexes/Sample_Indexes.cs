// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

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

            RequestContent content = RequestContent.Create(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            });

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            var index = projectClient.Indexes.CreateOrUpdate(
                name: indexName,
                version: indexVersion,
                content: content
            );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            DatasetIndex retrievedIndex = projectClient.Indexes.GetIndex(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            foreach (DatasetIndex version in projectClient.Indexes.GetVersions(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine($"Listing all Indices:");
            foreach (DatasetIndex version in projectClient.Indexes.GetIndices())
            {
                Console.WriteLine(version);
            }

            Console.WriteLine("Delete the Index version created above:");
            projectClient.Indexes.Delete(name: indexName, version: indexVersion);
            #endregion
        }
    }
}
