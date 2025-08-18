// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Identity;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    public class IndexesTest : ProjectsClientTestBase
    {
        public IndexesTest(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task SearchIndexesTest()
        {
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var indexName = TestEnvironment.INDEXNAME ?? "my-index";
            var indexVersion = TestEnvironment.INDEXVERSION ?? "1.0";
            var aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME ?? "my-ai-search-connection-name";
            var aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME ?? "my-ai-search-index-name";

            AIProjectClient projectClient = GetTestClient();

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
            TestBase.ValidateIndex(
                index,
                expectedIndexType: "AzureSearch",
                expectedIndexName: indexName,
                expectedIndexVersion: indexVersion,
                expectedAiSearchConnectionName: aiSearchConnectionName,
                expectedAiSearchIndexName: aiSearchIndexName
            );

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            SearchIndex retrievedIndex = await projectClient.Indexes.GetAsync(name: indexName, version: indexVersion);
            TestBase.ValidateIndex(
                retrievedIndex,
                expectedIndexType: "AzureSearch",
                expectedIndexName: indexName,
                expectedIndexVersion: indexVersion,
                expectedAiSearchConnectionName: aiSearchConnectionName,
                expectedAiSearchIndexName: aiSearchIndexName
            );

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            bool isEmpty = true;
            await foreach (SearchIndex version in projectClient.Indexes.GetVersionsAsync(name: indexName))
            {
                isEmpty = false;
                TestBase.ValidateIndex(version);
            }
            Assert.IsFalse(isEmpty, "Expected at least one version of the Index to be returned.");

            Console.WriteLine($"Listing all Indices:");
            isEmpty = true;
            await foreach (SearchIndex version in projectClient.Indexes.GetAsync())
            {
                isEmpty = false;
                TestBase.ValidateIndex(version);
            }
            Assert.IsFalse(isEmpty, "Expected at least one Index to be returned.");

            Console.WriteLine("Delete the Index version created above:");
            await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion); // TODO: why is delete failing????? 500 error but works in python

            Console.WriteLine("Attempt to delete again. It does not exist and should return 204:");
            await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion);
        }
    }
}
