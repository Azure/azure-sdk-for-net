// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
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
            #region Snippet:IndexesExampleSync
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
            Indexes indexesClient = projectClient.GetIndexesClient();

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            var index = indexesClient.CreateVersion(
                name: indexName,
                version: indexVersion,
                body: new AzureAISearchIndex(connectionName: aiSearchConnectionName, indexName: aiSearchIndexName)
                );
            Console.WriteLine(index);

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            var retrievedIndex = indexesClient.GetVersion(name: indexName, version: indexVersion);
            Console.WriteLine(retrievedIndex);

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            foreach (var version in indexesClient.GetVersions(name: indexName))
            {
                Console.WriteLine(version);
            }

            Console.WriteLine("List latest versions of all Indexes:");
            foreach (var latestIndex in indexesClient.GetLatests())
            {
                Console.WriteLine(latestIndex);
            }

            Console.WriteLine("Delete the Index versions created above:");
            indexesClient.DeleteVersion(name: indexName, version: indexVersion);
            #endregion
        }
    }
}
